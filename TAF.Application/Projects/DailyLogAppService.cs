// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyLogAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   工作日志服务
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

    using SCBF.Projects.Dto;

    /// <summary>
    /// 工作日志服务
    /// </summary>
    [AbpAuthorize]
    public class DailyLogAppService : TAFAppServiceBase, IDailyLogAppService
    {
        private readonly IDailyLogRepository dailyLogRepository;
        private readonly IProjectTaskRepository taskRepository;
        private readonly IProjectRepository projectRepository;

        public DailyLogAppService(IDailyLogRepository dailyLogRepository, IProjectTaskRepository taskRepository, IProjectRepository projectRepository)
        {
            this.dailyLogRepository = dailyLogRepository;
            this.taskRepository = taskRepository;
            this.projectRepository = projectRepository;
        }

        public ListResultDto<DailyLogListDto> GetAll(DailyLogQueryDto request)
        {
            var query = this.dailyLogRepository.GetAll()

                .WhereIf(request.TaskId.HasValue, r => r.TaskId == request.TaskId.Value)
                .WhereIf(request.DateFrom.HasValue, r => r.Date >= request.DateFrom.Value)
                .WhereIf(request.DateTo.HasValue, r => r.Date <= request.DateTo.Value)
                .WhereIf(request.ProjectId.HasValue, r => r.ProjectId == request.ProjectId.Value)
                .WhereIf(!string.IsNullOrWhiteSpace(request.Note), r => r.Note.Contains(request.Note))
                .WhereIf(request.TimeConsuming.HasValue, r => r.TimeConsuming == request.TimeConsuming.Value)
                .WhereIf(request.ResponsiblePersonId != 0, r => r.ResponsiblePersonId == request.ResponsiblePersonId)

                .WhereIf(request.Schedule.HasValue, r => r.Schedule == request.Schedule.Value);

            query = !string.IsNullOrWhiteSpace(request.Sorting)
                        ? query.OrderBy(request.Sorting)
                        : query.OrderBy(r => r.Date);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<DailyLogListDto>>();

            return new PagedResultDto<DailyLogListDto>(count, dtos);
        }

        public DailyLogEditDto Get(Guid id)
        {
            var output = this.dailyLogRepository.Get(id);
            return output.MapTo<DailyLogEditDto>();
        }

        public async Task SaveAsync(DailyLogEditDto input)
        {
            var item = input.MapTo<DailyLog>();
            if (input.Id == Guid.Empty)
            {
                await this.dailyLogRepository.InsertAsync(item);
            }
            else
            {
                var old = this.dailyLogRepository.Get(input.Id);
                Mapper.Map(input, old);
                await this.dailyLogRepository.UpdateAsync(old);
            }

            var task = this.taskRepository.Get(input.TaskId);
            if (task != null)
            {
                task.Schedule = input.Schedule;

                this.taskRepository.Update(task);
                if (task.Project.Tasks.All(r => r.Schedule == 100))
                {
                    task.Project.IsCompleted = true;
                    this.taskRepository.Update(task);
                }
            }
        }

        public void Delete(Guid id)
        {
            this.dailyLogRepository.Delete(id);
        }

        public List<ProjectSummaryDto> GetDailyLogs(DateTimeQueryDto query)
        {
            var list = this.projectRepository.GetAll().MapTo<List<ProjectSummaryDto>>();
            list.ForEach(
                r =>
                    {
                        r.Tasks.ForEach(
                            m =>
                                {
                                    m.DailyLogs = m.DailyLogs.OrderBy(n => n.Date).ToList();
                                });
                    });
            return list;
        }
    }
}



