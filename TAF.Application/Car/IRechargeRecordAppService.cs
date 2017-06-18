// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRechargeRecordAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   油料分配记录应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Car
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.Car.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 油料分配记录应用接口
    /// </summary>
    public interface IRechargeRecordAppService : IBaseEntityApplicationService
    {
        ListResultDto<RechargeRecordListDto> GetAll(RechargeRecordQueryDto request);

        RechargeRecordEditDto Get(Guid id);

        Task SaveAsync(RechargeRecordEditDto input);

        void Delete(Guid id);
    }
}



