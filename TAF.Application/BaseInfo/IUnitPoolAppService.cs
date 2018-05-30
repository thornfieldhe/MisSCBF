// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitPoolAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   模块附件关联应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TAF.Utility;

namespace SCBF.BaseInfo
{
    using System;
    using System.Threading.Tasks;
    using Abp.Application.Services.Dto;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 模块附件关联应用接口
    /// </summary>
    public interface IUnitPoolAppService : IBaseEntityApplicationService
    {
        PagedResultDto<UnitPoolListDto> GetAll(string category);


        Task SaveAsync(UnitPoolEditDto input);

        KeyValue<Guid, string> GetRandomItem(string category);
    }
}



