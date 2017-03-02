// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILayerAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   商品类别应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    using System.Collections.Generic;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 商品类别应用接口
    /// </summary>
    public interface ILayerAppService : IDefaultEntityApplicationService<LayerListDto, LayerEditDto, LayerQueryDto>
    {
        List<TreeItemDto> GetAllByCategory(string category);
    }
}



