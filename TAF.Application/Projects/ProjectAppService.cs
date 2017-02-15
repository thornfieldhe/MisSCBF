// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   ProductAppService
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Text;
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
    /// 
    /// </summary>
    [AbpAuthorize]
    public class ProjectAppService : TAFAppServiceBase, IProjectAppService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IDailyLogRepository dailyLogRepository;

        public ProjectAppService(IProjectRepository projectRepository, IDailyLogRepository dailyLogRepository)
        {
            this.projectRepository = projectRepository;
            this.dailyLogRepository = dailyLogRepository;
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public ListResultDto<ProjectListDto> GetAll(ProjectQueryDto request)
        {
            var query = this.projectRepository.GetAllIncluding(r => r.Tasks)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Name), r => r.Name.Contains(request.Name))
                .WhereIf(request.IsCompleted.HasValue, r => r.IsCompleted == request.IsCompleted.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ProjectListDto>>();

            return new PagedResultDto<ProjectListDto>(count, dtos);
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public ProjectEditDto Get(Guid id)
        {
            var output = this.projectRepository.Get(id);
            return output.MapTo<ProjectEditDto>();
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public async Task SaveAsync(ProjectEditDto input)
        {
            var item = input.MapTo<Project>();
            if (input.Id == Guid.Empty)
            {
                await this.projectRepository.InsertAsync(item);
            }
            else
            {
                var old = this.projectRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.projectRepository.UpdateAsync(old);
            }
        }

        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public void Delete(Guid id)
        {
            this.projectRepository.Delete(id);
        }

        [AbpAuthorize(PermissionNames.Pages)]
        public List<KeyValue<string, Guid>> GetSimpleList()
        {
            return this.projectRepository.GetAll().Select(r => new KeyValue<string, Guid> { Key = r.Name, Value = r.Id }).ToList();
        }

        /// <summary>
        /// 获取项目汇总图表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public string GetStatisticForProjet(DateTimeQueryDto query)
        {
            var list = (from d in this.dailyLogRepository.GetAll()
                        join p in this.projectRepository.GetAll() on d.ProjectId equals p.Id
                        where
                            ((query.DateFrom.HasValue && d.Date >= query.DateFrom.Value) || !query.DateFrom.HasValue)
                            && ((query.DateTo.HasValue && d.Date <= query.DateTo.Value) || !query.DateTo.HasValue)
                        group d by p.Name
                        into m
                        select new KeyValue<string, double>() { Key = m.Key, Value = m.Sum(r => r.Schedule) / 8.0 })
                .ToList();
            var line = new StringBuilder();
            line.Append("Morris.Bar({ element: 'statisticForProjet',data:[");

            foreach (var project in list)
            {
                line.Append($"{{'ProjectName':'{project.Key}','TimeConsuming':'{project.Value}'}},");
            }
            return $"{line.ToString().Trim(',')}],xkey: 'ProjectName',ykeys: ['TimeConsuming'],labels: ['耗时(d)']}})";
        }

        /// <summary>
        /// 获取人员汇总图表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AbpAuthorize(PermissionNames.PagesProjectManager)]
        public string GetStatisticForUser(DateTimeQueryDto query)
        {
            var list = (from d in this.dailyLogRepository.GetAll()
                        join p in this.projectRepository.GetAll() on d.ProjectId equals p.Id
                        where
                            ((query.DateFrom.HasValue && d.Date >= query.DateFrom.Value) || !query.DateFrom.HasValue)
                            && ((query.DateTo.HasValue && d.Date <= query.DateTo.Value) || !query.DateTo.HasValue)
                        select new
                        {
                            ResponsiblePerson = d.ResponsiblePerson.Name,
                            ProductName = p.Name,
                            TimeConsuming = d.TimeConsuming
                        })
                .ToList();
            var line = new StringBuilder();
            line.Append("Morris.Bar({ element: 'statisticForUser',data:[");
            var users = list.Select(r => r.ResponsiblePerson).Distinct().ToList();
            foreach (var user in users)
            {
                line.Append($"{{'ResponsiblePerson':'{user}'");
                var projects = list.Where(r => r.ResponsiblePerson == user);
                var userProjects = (from p in projects
                                    group p by p.ProductName
                            into b
                                    select new
                                    {
                                        ProjectName = b.Key,
                                        Total = b.Sum(r => r.TimeConsuming)
                                    }).ToList();

                foreach (var project in userProjects)
                {
                    line.Append(
                        $",'{project.ProjectName}':{string.Format("{0:0.0}", project.Total / 8.0)}");
                }

                line.Append("},");
            }

            var projectNames = list.Select(r => $"'{r.ProductName}'").Distinct().ToList();
            return $"{line.ToString().Trim(',')}],xkey: 'ResponsiblePerson',ykeys: [{string.Join(",", projectNames)}],labels: [{string.Join(",", projectNames.Select(r => r.TrimEnd('\'') + "耗时(d)'"))}]}})";
        }
    }
}