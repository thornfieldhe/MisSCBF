// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IProductAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.Storage.Dto;

    /// <summary>
    /// 商品应用接口
    /// </summary>
    public interface IProductAppService : IBaseEntityApplicationService
    {
        ListResultDto<ProductListDto> GetAll(ProductQueryDto request);

        ProductEditDto Get(Guid id);

        Task SaveAsync(ProductEditDto input);

        void Delete(Guid id);
    }
}



