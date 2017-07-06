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
    using SCBF.Car.Dto;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// 实物油料入库单应用接口
    /// </summary>
    public interface IOilRechargeRecordAppService : IBaseEntityApplicationService
    {
        List<OilRechargeRecordListDto> GetAll();

        OilRechargeRecordEditDto Get(Guid id);

        Task SaveAsync(OilRechargeRecordEditDto input);

        void Delete(Guid id);
    }
}



