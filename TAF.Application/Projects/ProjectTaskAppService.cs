// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProjectTaskRepository.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   项目任务服务
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects
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

    using SCBF.Authorization;
    using SCBF.Projects.Dto;
    using SCBF.Utility;

    /// <summary>
    /// 项目任务服务
    /// </summary>
    [AbpAuthorize]
    public class ProjectTaskAppService : TAFAppServiceBase, IProjectTaskAppService
    {
        private readonly IProjectTaskRepository projectTaskRepository;
        private readonly IProjectRepository projecRepository;

        public ProjectTaskAppService(IProjectTaskRepository projectTaskRepository, IProjectRepository projecRepository)
        {
            this.projectTaskRepository = projectTaskRepository;
            this.projecRepository = projecRepository;
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public ListResultDto<ProjectTaskListDto> GetAll(ProjectTaskQueryDto request)
        {
            var query = this.projectTaskRepository.GetAll()

                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                .WhereIf(request.ProjectId.HasValue, r => r.ProjectId == request.ProjectId.Value)
                .WhereIf(request.IsCompleted.HasValue, r => r.Schedule == 100);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ProjectTaskListDto>>();

            return new PagedResultDto<ProjectTaskListDto>(count, dtos);
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public ProjectTaskEditDto Get(Guid id)
        {
            var output = this.projectTaskRepository.Get(id);
            return output.MapTo<ProjectTaskEditDto>();
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public async Task SaveAsync(ProjectTaskEditDto input)
        {
            var item = input.MapTo<ProjectTask>();
            if (input.Id == Guid.Empty)
            {
                await this.projectTaskRepository.InsertAsync(item);
            }
            else
            {
                var old = this.projectTaskRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.projectTaskRepository.UpdateAsync(old);
            }

            var project = this.projecRepository.Get(input.ProjectId);
            if (project != null)
            {
                if (project.Tasks.All(r => r.Schedule == 100))
                {
                    project.IsCompleted = true;

                }
                else
                {
                    project.IsCompleted = false;
                }

                this.projecRepository.Update(project);
            }
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public void Delete(Guid id)
        {
            this.projectTaskRepository.Delete(id);
        }

        [AbpAuthorize(PermissionNames.Pages)]
        public List<KeyValue<string, Guid>> GetSimpleList(Guid? projectId = null)
        {
            return this.projectTaskRepository
                .GetAll()
                .WhereIf(projectId != null, r => r.ProjectId == projectId.Value)
                .WhereIf(projectId == null, r => r.ProjectId == Guid.NewGuid())
                .Select(r => new KeyValue<string, Guid> { Key = r.Name, Value = r.Id })
                .ToList();
        }
    }
}



