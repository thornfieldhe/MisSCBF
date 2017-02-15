// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TAF.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   IEntityApplicationService
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    /// <summary>
    /// 实体服务基类
    /// </summary>
    /// <typeparam name="T">列表对象</typeparam>
    /// <typeparam name="K">编辑对象</typeparam>
    /// <typeparam name="P">查询对象</typeparam>
    /// <typeparam name="O">主键</typeparam>
    public interface IBaseEntityApplicationService<T, K, P, O> : IApplicationService
    {
        ListResultDto<T> GetAll(P request);

        K Get(O id);

        Task SaveAsync(K input);

        void Delete(O id);
    }
}