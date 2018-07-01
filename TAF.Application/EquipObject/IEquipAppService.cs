// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEquipAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   装备管理应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.EquipObject
{
    using System;
    using System.Threading.Tasks;

    using SCBF.EquipObject.Dto;

    /// <summary>
    /// 装备管理应用接口
    /// </summary>
    public interface IEquipAppService : IBaseEntityApplicationService
    {

        EquipEditDto Get(Guid id);

        Task SaveAsync(EquipEditDto input);

        void Delete(Guid id);
    }
}



