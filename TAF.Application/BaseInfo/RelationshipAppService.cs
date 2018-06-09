// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationshipAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   关系管理服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 关系管理服务
    /// </summary>
    [AbpAuthorize]
    public class RelationshipAppService : TAFAppServiceBase, IRelationshipAppService
    {
        private readonly IRelationshipRepository _relationshipRepository;

        public RelationshipAppService(IRelationshipRepository relationshipRepository)
        {
            this._relationshipRepository = relationshipRepository;
        }

        public void Add(RelationshipEditDto input)
        {
            var item = input.MapTo<Relationship>();
            this._relationshipRepository.Insert(item);
        }

        public void Remove(Guid id)
        {
            this._relationshipRepository.Delete(id);
        }

        public void RemovePrincipalKey(Guid id)
        {
            this._relationshipRepository.Delete(r=>r.PrincipalKey==id);
        }

        public void RemoveForeignKey(Guid id)
        {
            this._relationshipRepository.Delete(r=>r.ForeignKey==id);
        }
    }
}
