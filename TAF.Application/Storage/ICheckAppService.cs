// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICheckAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Threading.Tasks;
    
    using SCBF.Storage.Dto;
    
   using Abp.Application.Services.Dto;
    
    /// <summary>
    /// 盘点应用接口
    /// </summary>
    public interface ICheckAppService : IBaseEntityApplicationService
    {
        ListResultDto<CheckListDto> GetAll(CheckQueryDto request);

        CheckEditDto Get(Guid id);

        Task SaveAsync(CheckEditDto input);

        void Delete(Guid id);
    }
}



