// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScheduledTaskAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务服务
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
    using Abp.Quartz.Quartz;

    using AutoMapper;

    using Quartz;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 计划任务服务
    /// </summary>
    [AbpAuthorize]
    public class ScheduledTaskAppService : TAFAppServiceBase, IScheduledTaskAppService
    {
        private readonly IScheduledTaskRepository scheduledTaskRepository;
        private readonly IQuartzScheduleJobManager jobManager;

        public ScheduledTaskAppService(IScheduledTaskRepository scheduledTaskRepository
            , IQuartzScheduleJobManager jobManager)
        {
            this.scheduledTaskRepository = scheduledTaskRepository;
            this.jobManager = jobManager;
        }

        public ListResultDto<ScheduledTaskListDto> GetAll(PagedAndSortedResultRequestDto request)
        {
            var query = this.scheduledTaskRepository.GetAll().OrderBy(r => r.Name);
            var count = query.Count();
            var list = query.AsQueryable().PageBy(request).ToList();
            var dtos = list.MapTo<List<ScheduledTaskListDto>>();

            return new PagedResultDto<ScheduledTaskListDto>(count, dtos);
        }

        public async Task Execute(KeyValuePair<Guid, bool> input)
        {
            await this.jobManager.ScheduleAsync<ChangeYearTask>(
                job =>
                {
                    job.WithIdentity("MyLogJobIdentity", "MyGroup")
                        .WithDescription("A job to simply write logs.");
                },
                trigger =>
                    {
                        trigger.WithIdentity("MyLogJobIdentity", "MyGroup").WithSchedule(CronScheduleBuilder.CronSchedule("30 * * * * * ")).Build();

                    });
        }
    }
}



