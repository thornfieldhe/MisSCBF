// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheckAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票录入服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using Abp.UI;
using AutoMapper;
using SCBF.Finance.Dto;

namespace SCBF.Finance
{
	/// <summary>
    /// 发票录入服务
    /// </summary>
    [AbpAuthorize]
    public class InvoiceCheckAppService : TAFAppServiceBase, IInvoiceCheckAppService
    {
        private readonly IInvoiceCheckRepository _invoiceCheckRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceCheckAppService(IInvoiceCheckRepository invoiceCheckRepository, IInvoiceRepository invoiceRepository)
        {
            this._invoiceCheckRepository = invoiceCheckRepository;
            this._invoiceRepository = invoiceRepository;
        }

        public ListResultDto<InvoiceCheckListDto> GetAll(InvoiceCheckQueryDto request)
        {
            var query = this._invoiceCheckRepository.GetAll().WhereIf(request.To.HasValue, r => r.From == request.To)
                .WhereIf(request.From.HasValue, r => r.From == request.From);
            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderByDescending(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<InvoiceCheckListDto>>();

            return new PagedResultDto<InvoiceCheckListDto>(count, dtos);
        }

        public InvoiceCheckEditDto Get(Guid id)
        {
            var output = this._invoiceCheckRepository.Get(id);
            return output.MapTo<InvoiceCheckEditDto>();
        }

        public async Task SaveAsync(InvoiceCheckEditDto input)
        {
            if (input.From > input.To && input.To != 0)
            {
                throw new UserFriendlyException("起始发票号应小于截止发票号");
            }

            if (!input.To.HasValue || input.To == 0)
            {
                input.To = input.From;
            }

            var item = input.MapTo<InvoiceCheck>();
            if (!input.Id.HasValue)
            {
                var r = await this._invoiceCheckRepository.InsertAsync(item);
                var list = new List<Invoice>();
                for (long i = input.From; i <= input.To.Value; i++)
                {
                    list.Add(new Invoice { Code = i.ToString(), InvoiceCheckId = r.Id });
                }
                this._invoiceRepository.InsertRange(list);
            }
            else
            {
                var old = this._invoiceCheckRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._invoiceCheckRepository.UpdateAsync(old);
                this._invoiceRepository.Delete(r => r.InvoiceCheckId == old.Id);
                var list = new List<Invoice>();
                for (long i = input.From; i <= input.To.Value; i++)
                {
                    list.Add(new Invoice { Code = i.ToString(), Id = Guid.NewGuid(), InvoiceCheckId = old.Id });
                }

                this._invoiceRepository.InsertRange(list);
            }
        }

        public void Delete(Guid id)
        {
            this._invoiceCheckRepository.Delete(id);
        }

        public string Check(Guid id)
        {
            var item = this._invoiceCheckRepository.Get(id);
            if (item == null)
            {
                throw new UserFriendlyException("发票不存在!");
            }
            var code = item.Invoices.First();
            var list = this._invoiceRepository
                .GetAllList(
                    r => r.Code.StartsWith(code.Code.Substring(0, code.Code.Length - 4))
                         && r.InvoiceCheckId != code.InvoiceCheckId && r.Code.Length == code.Code.Length)
                .Select(r => r.Code).OrderBy(r => r).ToList();
            if (list.Count > 0)
            {
                return $"存在连号发票,[{string.Join(",", list)}]";
            }

            return "";
        }
    }
}



