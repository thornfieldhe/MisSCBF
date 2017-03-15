// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISysDictionaryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   系统配置应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System.Collections.Generic;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 系统配置应用接口
    /// </summary>
    public interface ISysDictionaryAppService : IDefaultEntityApplicationService<SysDictionaryListDto, SysDictionaryEditDto, SysDictionaryQueryDto>
    {
        List<SysDictionaryListDto> GetSimpleList();
    }
}



