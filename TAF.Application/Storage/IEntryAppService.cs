// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntryAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   入库应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System.Collections.Generic;

    using Abp.Application.Services.Dto;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 入库应用接口
    /// </summary>
    public interface IEntryAppService : IBaseEntityApplicationService
    {
        ListResultDto<EntryListDto> SaveAll(List<EntryEditDto> list);
    }
}



