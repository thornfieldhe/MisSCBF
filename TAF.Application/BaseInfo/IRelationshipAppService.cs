// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRelationshipAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    
    using SCBF.BaseInfo.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 关系管理应用接口
    /// </summary>
    public interface IRelationshipAppService : IBaseEntityApplicationService
    {
        ListResultDto<RelationshipListDto> GetAll(RelationshipQueryDto request);

        RelationshipEditDto Get(Guid id);

        Task SaveAsync(RelationshipEditDto input);

        void Delete(Guid id);
    }
}



