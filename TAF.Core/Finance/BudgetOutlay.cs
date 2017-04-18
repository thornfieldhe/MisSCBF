﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetOutlays.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   BudgetOutlays
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class BudgetOutlay : TAFEntity
    {
        /// <summary>
        /// 科目代码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 会计年
        /// </summary>
        public int Year
        {
            get; set;
        }

        /// <summary>
        /// 同一批次导入的预算文件的文件Id保持一致
        /// </summary>
        public string FileId
        {
            get; set;
        }


        /// <summary>
        /// 导入时的Sheet标签
        /// </summary>
        public string SheetName
        {
            get; set;
        }

        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit
        {
            get; set;
        }

        /// <summary>
        /// 是否关联预算收入
        /// </summary>
        public bool HasRelated
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 单价或金额标准或支出限额
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 关联预算收入Id
        /// </summary>
        public Guid? ReceiptId
        {
            get; set;
        }



        #region 栏目

        /// <summary>
        /// 栏目1(标准经费)
        /// </summary>
        public decimal Column1
        {
            get; set;
        }

        /// <summary>
        /// 栏目2(项目经费)
        /// </summary>
        public decimal Column2
        {
            get; set;
        }


        /// <summary>
        /// 栏目3(直接支出)
        /// </summary>
        public decimal Column3
        {
            get; set;
        }

        #endregion
    }
}