// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TendererAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   投标人管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.AutoMapper;

    using SCBF.Purchase.Dto;

    /// <summary>
    /// 投标人管理服务
    /// </summary>
    [AbpAuthorize]
    public class TendererAppService : TAFAppServiceBase, ITendererAppService
    {
        private readonly ITendererRepository _tendererRepository;

        public TendererAppService(ITendererRepository tendererRepository)
        {
            this._tendererRepository = tendererRepository;
        }

        public List<TendererDto> GetAll(Guid biddingManagementId)
        {
            return this._tendererRepository.GetAllList(r=>r.BiddingManagementId==biddingManagementId).MapTo<List<TendererDto>>();
        }

        public async Task SaveAsync(List<TendererDto> inputs)
        {
            if(inputs.Count>0)
            {
                try
                {
                    var biddingManagementId = inputs[0].BiddingManagementId;
                    this._tendererRepository.Delete(r=>r.BiddingManagementId ==biddingManagementId);
                    var details = inputs.MapTo<List<Tenderer>>();
                    this._tendererRepository.InsertRange(details);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}



