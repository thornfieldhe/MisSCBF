// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOilRechargeRecordAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   实物油料入库单应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using Abp.Application.Services.Dto;
    using SCBF.Car.Dto;
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料入库单应用接口
    /// </summary>
    public interface IOilRechargeRecordAppService : IBaseEntityApplicationService
    {
        PagedResultDto<OilRechargeRecordListDto> GetAll(PagedAndSortedResultRequestDto request);

        OilRechargeRecordEditDto Get(Guid id);

        Task SaveAsync(OilRechargeRecordEditDto input);
    }
}



