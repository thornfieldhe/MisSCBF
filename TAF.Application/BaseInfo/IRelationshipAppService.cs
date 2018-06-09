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

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 关系管理应用接口
    /// </summary>
    public interface IRelationshipAppService : IBaseEntityApplicationService
    {


        void Add(RelationshipEditDto input);

        void Remove(Guid id);
        void RemovePrincipalKey(Guid id);
        void RemoveForeignKey(Guid id);

    }
}



