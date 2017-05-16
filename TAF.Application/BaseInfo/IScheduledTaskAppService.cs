// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScheduledTaskAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   计划任务应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    using SCBF.BaseInfo.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 计划任务应用接口
    /// </summary>
    public interface IScheduledTaskAppService : IBaseEntityApplicationService
    {
        ListResultDto<ScheduledTaskListDto> GetAll(PagedAndSortedResultRequestDto request);

        Task Execute(KeyValuePair<Guid, bool> input);
    }
}



