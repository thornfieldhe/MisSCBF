// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryCategory.cs" company="">
//   
// </copyright>
// <summary>
//   字典分类
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.BaseInfo
{
    public static class DictionaryCategory
    {
        #region 物资

        /// <summary>
        /// 商品分类
        /// </summary>
        public const string Mmaterial_ProductCategory = "Mmaterial_ProductCategory";

        /// <summary>
        /// 商品单位
        /// </summary>
        public const string Mmaterial_ProductUnit = "Mmaterial_ProductUnit";

        /// <summary>
        /// 仓库
        /// </summary>
        public const string Mmaterial_Storage = "Mmaterial_Storage";
        /// <summary>
        /// 会计年度
        /// </summary>
        public const string Material_Year = "Material_Year";
        #endregion

        #region 预算

        /// <summary>
        /// 预算年
        /// </summary>
        public const string Budget_Year = "Budget_Year";

        /// <summary>
        /// 会计科目
        /// </summary>
        public const string Budget_Account = "Budget_Account";

        #endregion

        #region 基础信息

        #endregion

        #region 附件信息
        /// <summary>
        /// 附件默认路径
        /// </summary>
        public const string Attachment_BashPath = "Attachment_BasePath";

        /// <summary>
        /// 附件后缀
        /// </summary>
        public const string Attachment_Ext = "Attachment_Ext";

        /// <summary>
        /// 预算收入附件
        /// </summary>
        public const string Attachment_BudgetReceipt = "Attachment_BudgetReceipt";

        /// <summary>
        /// 预算支出附件
        /// </summary>
        public const string Attachment_BudgetOutlays = "Attachment_BudgetOutlays";

        /// <summary>
        /// 实际支出附件
        /// </summary>
        public const string Attachment_ActualOutlays = "Attachment_ActualOutlays";

        #endregion

    }
}