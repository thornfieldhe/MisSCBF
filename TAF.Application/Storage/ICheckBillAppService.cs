// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICheckBillAppService.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   盘点应用接口
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Storage
{
    using System;

    /// <summary>
    /// 盘点应用接口
    /// </summary>
    public interface ICheckBillAppService : IBaseEntityApplicationService
    {
        Guid LoadCheckFile(string path, object param);
    }
}



