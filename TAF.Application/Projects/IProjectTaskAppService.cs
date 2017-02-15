// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects
{
    using System;
    using System.Collections.Generic;

    using SCBF.Projects.Dto;
    using SCBF.Utility;

    /// <summary>
    /// 项目任务应用接口
    /// </summary>
    public interface IProjectTaskAppService : IDefaultEntityApplicationService<ProjectTaskListDto, ProjectTaskEditDto, ProjectTaskQueryDto>
    {
        List<KeyValue<string, Guid>> GetSimpleList(Guid? projectId);
    }
}



