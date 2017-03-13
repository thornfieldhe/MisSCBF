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
    using SCBF.Storage.Dto;

    /// <summary>
    /// 商品应用接口
    /// </summary>
    public interface IProductAppService : IDefaultEntityApplicationService<ProductListDto, ProductEditDto, ProductQueryDto>
    {

    }
}



