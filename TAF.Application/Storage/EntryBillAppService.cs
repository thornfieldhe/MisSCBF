// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntryBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using AutoMapper;

    using SCBF.Storage.Dto;

    using TAF.Utility;

    /// <summary>
    /// 入库单服务
    /// </summary>
    [AbpAuthorize]
    public class EntryBillAppService : TAFAppServiceBase, IEntryBillAppService
    {
        private readonly IEntryBillRepository entryBillRepository;

        public EntryBillAppService(IEntryBillRepository entryBillRepository)
        {
            this.entryBillRepository = entryBillRepository;
        }



        public async Task SaveAsync(EntryBillEditDto input)
        {
            var item = input.MapTo<EntryBill>();
            if (input.Id == Guid.Empty)
            {
                item.Code = GetMaxCode();
                await this.entryBillRepository.InsertAsync(item);
            }
            else
            {
                var old = this.entryBillRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.entryBillRepository.UpdateAsync(old);
            }
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.entryBillRepository.Get(r => r.Code.StartsWith($"RK{preCode}"))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if(string.IsNullOrWhiteSpace(maxCode))
            {
                return $"RK{preCode}001";
            }
            else
            {
                return $"RK{maxCode.ToInt()+1}";
            }
        }
    }
}



