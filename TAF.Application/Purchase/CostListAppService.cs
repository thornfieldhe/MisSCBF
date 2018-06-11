// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CostListAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   造价清单管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using AutoMapper;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 造价清单管理服务
    /// </summary>
    [AbpAuthorize]
    public class CostListAppService : TAFAppServiceBase, ICostListAppService
    {
        private readonly ICostListRepository _costListRepository;

        public CostListAppService(ICostListRepository costListRepository)
        {
            this._costListRepository = costListRepository;
        }

        public List<CostListDto> GetAll(Guid biddingManagementId)
        {
            var query = this._costListRepository.GetAllList(r=>r.BiddingManagementId==biddingManagementId); 
            return query.MapTo<List<CostListDto>>();
        }

        public CostListDto Get(Guid id)
        {
            var output = this._costListRepository.Get(id);
            return output.MapTo<CostListDto>();
        }

        public async Task SaveAsync(CostListDto input)
        {
            var item = input.MapTo<CostList>();
            if (!input.Id.HasValue)
            {
                await this._costListRepository.InsertAsync(item);
            }
            else
            {
                var old = this._costListRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._costListRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._costListRepository.Delete(id);
        }
    }
}



