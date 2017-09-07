// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OilRechargeRecordAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料入库单服务
    /// </summary>
    [AbpAuthorize]
    public class OilRechargeRecordAppService : TAFAppServiceBase, IOilRechargeRecordAppService
    {
        private readonly IOilRechargeRecordRepository oilRechargeRecordRepository;
        private readonly ISysDictionaryRepository sysDictionaryRepository;
        private readonly IOctaneStoreRepository octaneStoreRepository;

        public OilRechargeRecordAppService(IOilRechargeRecordRepository oilRechargeRecordRepository,
            ISysDictionaryRepository sysDictionaryRepository,
            IOctaneStoreRepository octaneStoreRepository)
        {
            this.oilRechargeRecordRepository = oilRechargeRecordRepository;
            this.sysDictionaryRepository = sysDictionaryRepository;
            this.octaneStoreRepository = octaneStoreRepository;
        }

        public PagedResultDto<OilRechargeRecordListDto> GetAll(PagedAndSortedResultRequestDto request)
        {
            var query = this.oilRechargeRecordRepository.GetAll()
                        .OrderByDescending(r => r.CreationTime).OrderByDescending(r => r.CreationTime).ToList();
            var count = query.Count();
            var result = new List<OilRechargeRecordListDto>();
            foreach (var record in query)
            {
                var item = new OilRechargeRecordListDto()
                {
                    Amount = record.Amount,
                    Code = record.Code,
                    Date = record.CreationTime.ToString("yyyy-MM-dd"),
                    Note = record.Note
                };
                var octaneStore = this.octaneStoreRepository.FirstOrDefault(r => r.Id == record.OctanceId);
                if (octaneStore == null)
                {
                    throw new UserFriendlyException("油料代管单位内不存在该油料标号");
                }

                item.StoreName = this.sysDictionaryRepository.FirstOrDefault(r => r.Id == octaneStore.StoreId)?.Value;
                item.Rating = this.sysDictionaryRepository.FirstOrDefault(r => r.Id == octaneStore.OctaneRatingId)?.Value;
                result.Add(item);
            }

            return new PagedResultDto<OilRechargeRecordListDto>(count, result);
        }

        public OilRechargeRecordEditDto Get(Guid id)
        {
            var output = this.oilRechargeRecordRepository.Get(id);
            return output.MapTo<OilRechargeRecordEditDto>();
        }

        public async Task SaveAsync(OilRechargeRecordEditDto input)
        {
            var store = this.octaneStoreRepository.FirstOrDefault(r => r.OctaneRatingId == input.OctanceId && r.StoreId == input.StoreId);
            if (store == null)
            {
                throw new UserFriendlyException("代管单位下不存在该油料");
            }
            var item = new OilRechargeRecord()
            {
                Code = GetMaxCode(),
                Amount = input.Amount,
                AttachmentId = input.AttachmentId,
                Note = input.Note,
                OctanceId = store.Id
            };

            await this.oilRechargeRecordRepository.InsertAsync(item);
            store.Amount += item.Amount;
            await this.octaneStoreRepository.UpdateAsync(store);
        }

        private string GetMaxCode()
        {
            var preCode = DateTime.Today.ToString("yyyyMMdd");
            var maxCode =
                this.oilRechargeRecordRepository.Get(r => r.Code.StartsWith("SWRK" + preCode))
                    .OrderByDescending(r => r.Code)
                    .FirstOrDefault()?.Code;
            if (string.IsNullOrWhiteSpace(maxCode))
            {
                return $"SWRK{preCode}001";
            }
            else
            {
                return $"SWRK{(long.Parse(maxCode.Substring(3)) + 1):000}";
            }
        }
    }
}



