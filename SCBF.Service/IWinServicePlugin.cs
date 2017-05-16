// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SCBF.Service.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   IWinServicePlugin
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Service
{
    using Quartz;

    /// <summary>
    /// 系统服务插件接口
    /// </summary>
    public interface IWinServicePlugin : IJob
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 插件启动
        /// </summary>
        /// <returns></returns>
        bool Start();

        /// <summary>
        /// 插件停止
        /// </summary>
        /// <returns></returns>
        bool Stop();
    }
}