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
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using SCBF.BaseInfo.Dto;

    /// <summary>
    /// 商品类别应用接口
    /// </summary>
    public interface ILayerAppService : IBaseEntityApplicationService
    {
        List<TreeItemDto> GetAllByCategory(string category);

        Task SaveAsync(LayerEditDto input);

        void Delete(Guid id);

        LayerEditDto Get(Guid id);

        ListResultDto<LayerListDto> GetAll(LayerQueryDto request);
    }
}



