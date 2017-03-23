// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISysSysDictionaryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 系统配置应用接口
    /// </summary>
    public interface ISysDictionaryAppService : IBaseEntityApplicationService
    {
        ListResultDto<SysDictionaryListDto> GetAll(SysDictionaryQueryDto request);

        SysDictionaryEditDto Get(Guid id);

        Task SaveAsync(SysDictionaryEditDto input);

        void Delete(Guid id);

        List<SysDictionaryListDto> GetSimpleList();
    }
}



