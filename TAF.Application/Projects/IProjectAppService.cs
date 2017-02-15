// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   IProductAppService
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects
{
    using System;
    using System.Collections.Generic;

    using SCBF.Projects.Dto;
    using SCBF.Utility;

    public interface IProjectAppService : IDefaultEntityApplicationService<ProjectListDto, ProjectEditDto, ProjectQueryDto>
    {
        List<KeyValue<string, Guid>> GetSimpleList();

        string GetStatisticForProjet(DateTimeQueryDto query);

        string GetStatisticForUser(DateTimeQueryDto query);
    }
}