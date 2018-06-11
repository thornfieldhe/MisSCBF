// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PurchaseTypeInfo.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   招标类型附属属性
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Purchase
{
    /// <summary>
    /// 招标类型附属属性
    /// </summary>
    public static class PurchaseTypeInfo
    {
        #region 文件模板

        /// <summary>
        /// 资产/物资采购
        /// </summary>
        public static string ZccgFileTemplate => "资产/物资采购招标文件.doc";

        /// <summary>
        /// 服务采购
        /// </summary>
        public static string FwcgFileTemplate => "服务采购招标文件.doc";

        /// <summary>
        /// 信息化采购
        /// </summary>
        public static string XchcgFileTemplate => "信息化采购采购招标文件.doc";

        /// <summary>
        /// 工程采购
        /// </summary>
        public static string GccgFileTemplate => "工程采购采购招标文件.doc";
        #endregion

        #region 通知模板
        /// <summary>
        /// 资产/物资采购
        /// </summary>
        public static string ZccgNotifyTemplate => "资产/物资采购通知文件.doc";

        /// <summary>
        /// 服务采购
        /// </summary>
        public static string FwcgNotifyTemplate => "服务采购通知文件.doc";

        /// <summary>
        /// 信息化采购
        /// </summary>
        public static string XchcgNotifyTemplate => "信息化采购通知文件.doc";

        /// <summary>
        /// 工程采购
        /// </summary>
        public static string GccgNotifyTemplate => "工程采购通知文件.doc";
        #endregion

        #region 公示模板
        /// <summary>
        /// 资产/物资采购
        /// </summary>
        public static string ZccgPublicityTemplate => "资产/物资采购公示文件.doc";

        /// <summary>
        /// 服务采购
        /// </summary>
        public static string FwcgPublicityTemplate => "服务采购公示文件.doc";

        /// <summary>
        /// 信息化采购
        /// </summary>
        public static string XchcgPublicityTemplate => "信息化采购公示文件.doc";

        /// <summary>
        /// 工程采购
        /// </summary>
        public static string GccgPublicityTemplate => "工程采购公示文件.doc";
        #endregion
    }
}
