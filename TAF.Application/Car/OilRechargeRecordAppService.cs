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
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.UI;
    using AutoMapper;
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

        public List<OilRechargeRecordListDto> GetAll()
        {
            var query = this.oilRechargeRecordRepository.GetAll()
                        .OrderByDescending(r => r.CreationTime).ToList();
            var result = new List<OilRechargeRecordListDto>();
            foreach (var record in query)
            {
                var item = new OilRechargeRecordListDto() { Amount = record.Amount };
                var octaneStore = this.octaneStoreRepository.FirstOrDefault(r => r.Id == record.OctanceId);
                if (octaneStore == null)
                {
                    throw new UserFriendlyException("油料代管单位不存在");
                }

                item.OctanceStore = this.sysDictionaryRepository.FirstOrDefault(r => r.Id == octaneStore.StoreId)?.Value;
                item.Rating = this.sysDictionaryRepository.FirstOrDefault(r => r.Id == octaneStore.OctaneRatingId)?.Value;
            }

            return query.AsQueryable().MapTo<List<OilRechargeRecordListDto>>();
        }

        public OilRechargeRecordEditDto Get(Guid id)
        {
            var output = this.oilRechargeRecordRepository.Get(id);
            return output.MapTo<OilRechargeRecordEditDto>();
        }

        public async Task SaveAsync(OilRechargeRecordEditDto input)
        {
            var item = input.MapTo<OilRechargeRecord>();
            if (!input.Id.HasValue)
            {
                await this.oilRechargeRecordRepository.InsertAsync(item);
            }
            else
            {
                var old = this.oilRechargeRecordRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this.oilRechargeRecordRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this.oilRechargeRecordRepository.Delete(id);
        }
    }
}



