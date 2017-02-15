// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TAF.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   IDefaultEntityApplicationService
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF
{
    using System;

    /// <summary>
    /// 默认实体主键使用Guid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="P"></typeparam>
    public interface IDefaultEntityApplicationService<T, K, P> : IBaseEntityApplicationService<T, K, P, Guid>
    {
    }
}