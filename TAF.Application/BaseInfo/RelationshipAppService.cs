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
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.AutoMapper;
    using Abp.Linq.Extensions;

    using AutoMapper;

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

        public ListResultDto<RelationshipListDto> GetAll(RelationshipQueryDto request)
        {
            var query = this._relationshipRepository.GetAll()
            
                .WhereIf(request.PrincipalKey.HasValue, r => r.PrincipalKey == request.PrincipalKey.Value)             
                .WhereIf(request.ForeignKey.HasValue, r => r.ForeignKey == request.ForeignKey.Value)             
                .WhereIf(!string.IsNullOrWhiteSpace(request.Type), r => r.Type.Contains(request.Type));  

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.CreationTime);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<RelationshipListDto>>();

            return new PagedResultDto<RelationshipListDto>(count, dtos);
        }

        public RelationshipEditDto Get(Guid id)
        {
            var output = this._relationshipRepository.Get(id);
            return output.MapTo<RelationshipEditDto>();
        }

        public async Task SaveAsync(RelationshipEditDto input)
        {
            var item = input.MapTo<Relationship>();
            if (!input.Id.HasValue)
            {
                await this._relationshipRepository.InsertAsync(item);
            }
            else
            {
                var old = this._relationshipRepository.Get(input.Id.Value);
                Mapper.Map(input, old);
                await this._relationshipRepository.UpdateAsync(old);
            }
        }

        public void Delete(Guid id)
        {
            this._relationshipRepository.Delete(id);
        }
    }
}



