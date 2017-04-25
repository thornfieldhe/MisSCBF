// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BudgetReceipt.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   BudgetReceipt
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class BudgetReceipt : TAFEntity
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
        /// 预算类型
        /// </summary>
        public BungetType Type
        {
            get; set;
        }

        /// <summary>
        /// 同一批次导入的预算文件的文件Id保持一致
        /// </summary>
        public Guid FileId
        {
            get; set;
        }

        /// <summary>
        /// 预算支出列表
        /// </summary>
        public virtual List<BudgetOutlay> BudgetOutlaies
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
        /// 栏目1备注(标准经费)
        /// </summary>
        public string Note1
        {
            get; set;
        }

        /// <summary>
        /// 栏目21(项目经费-地方下达项目经费)
        /// </summary>
        public decimal Column21
        {
            get; set;
        }

        /// <summary>
        /// 栏目21备注(项目经费-地方下达项目经费)
        /// </summary>
        public string Note21
        {
            get; set;
        }

        /// <summary>
        /// 栏目22(项目经费-部局下达项目经费)
        /// </summary>
        public decimal Column22
        {
            get; set;
        }

        /// <summary>
        /// 栏目22备注(项目经费-部局下达项目经费)
        /// </summary>
        public string Note22
        {
            get; set;
        }

        #region 栏目3

        /// <summary>
        /// 栏目31(留用经费-留用党团费弥补)
        /// </summary>
        public decimal Column31
        {
            get; set;
        }

        /// <summary>
        /// 栏目31备注(留用经费-留用党团费弥补)
        /// </summary>
        public string Note31
        {
            get; set;
        }

        /// <summary>
        /// 栏目32(留用经费-留用租房维修基金弥补)
        /// </summary>
        public decimal Column32
        {
            get; set;
        }

        /// <summary>
        /// 栏目32备注(留用经费-留用租房维修基金弥补)
        /// </summary>
        public string Note32
        {
            get; set;
        }

        /// <summary>
        /// 栏目33(留用经费-历年预算外结余弥补)
        /// </summary>
        public decimal Column33
        {
            get; set;
        }

        /// <summary>
        /// 栏目33备注(留用经费-历年预算外结余弥补)
        /// </summary>
        public string Note33
        {
            get; set;
        }

        /// <summary>
        /// 栏目34(留用经费-历年预算经费结余弥补)
        /// </summary>
        public decimal Column34
        {
            get; set;
        }

        /// <summary>
        /// 栏目34备注(留用经费-历年预算经费结余弥补)
        /// </summary>
        public string Note34
        {
            get; set;
        }

        /// <summary>
        /// 栏目35(留用经费-当年地方保障经费弥补)
        /// </summary>
        public decimal Column35
        {
            get; set;
        }

        /// <summary>
        /// 栏目35备注(留用经费-当年地方保障经费弥补)
        /// </summary>
        public string Note35
        {
            get; set;
        }

        /// <summary>
        /// 栏目36(留用经费-当年预算外收入弥补)
        /// </summary>
        public decimal Column36
        {
            get; set;
        }

        /// <summary>
        /// 栏目36备注(留用经费-当年预算外收入弥补)
        /// </summary>
        public string Note36
        {
            get; set;
        }

        /// <summary>
        /// 栏目37(留用经费-其他收入弥补)
        /// </summary>
        public decimal Column37
        {
            get; set;
        }

        /// <summary>
        /// 栏目36备注(留用经费-其他收入弥补)
        /// </summary>
        public string Note37
        {
            get; set;
        }

        #endregion

        #region 栏目4

        /// <summary>
        /// 栏目41(上年结转-地方专项经费)
        /// </summary>
        public decimal Column41
        {
            get; set;
        }

        /// <summary>
        /// 栏目41备注(上年结转-地方专项经费)
        /// </summary>
        public string Note41
        {
            get; set;
        }

        /// <summary>
        /// 栏目42(上年结转-部局专项经费)
        /// </summary>
        public decimal Column42
        {
            get; set;
        }

        /// <summary>
        /// 栏目42备注(上年结转-部局专项经费)
        /// </summary>
        public string Note42
        {
            get; set;
        }

        /// <summary>
        /// 栏目43(上年结转-历年预算外结余)
        /// </summary>
        public decimal Column43
        {
            get; set;
        }

        /// <summary>
        /// 栏目43备注(上年结转-历年预算外结余)
        /// </summary>
        public string Note43
        {
            get; set;
        }

        /// <summary>
        /// 栏目44(上年结转-历年预算经费结余)
        /// </summary>
        public decimal Column44
        {
            get; set;
        }

        /// <summary>
        /// 栏目44备注(上年结转-历年预算经费结余)
        /// </summary>
        public string Note44
        {
            get; set;
        }

        /// <summary>
        /// 栏目45(上年结转-留用住房维修基金)
        /// </summary>
        public decimal Column45
        {
            get; set;
        }

        /// <summary>
        /// 栏目45备注(上年结转-留用住房维修基金)
        /// </summary>
        public string Note45
        {
            get; set;
        }

        /// <summary>
        /// 栏目46(上年结转-留用党团费)
        /// </summary>
        public decimal Column46
        {
            get; set;
        }

        /// <summary>
        /// 栏目46备注(上年结转-留用党团费)
        /// </summary>
        public string Note46
        {
            get; set;
        }

        /// <summary>
        /// 栏目47(上年结转-其他经费)
        /// </summary>
        public decimal Column47
        {
            get; set;
        }

        /// <summary>
        /// 栏目47备注(上年结转-其他经费)
        /// </summary>
        public string Note47
        {
            get; set;
        }

        #endregion

        /// <summary>
        /// 栏目5(上年结转-当年预算外收入)
        /// </summary>
        public decimal Column5
        {
            get; set;
        }

        /// <summary>
        /// 栏目5备注(上年结转-当年预算外收入)
        /// </summary>
        public string Note5
        {
            get; set;
        }

        #endregion

    }
}