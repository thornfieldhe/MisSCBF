namespace SCBF.Finance.Dto
{
    /// <summary>
    /// 年度预算简表
    /// </summary>
    public class YearBudgetSummaryDto
    {
        /// <summary>
        /// 科目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 科目编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 收入合计
        /// </summary>
        public decimal Total1
        {
            get; set;
        }

        /// <summary>
        /// 向上请领小计
        /// </summary>
        public decimal Total2
        {
            get; set;
        }

        /// <summary>
        /// 向上请领标准经费
        /// </summary>
        public decimal Column1
        {
            get; set;
        }

        /// <summary>
        /// 向上请领项目经费
        /// </summary>
        public decimal Column2
        {
            get; set;
        }

        /// <summary>
        /// 留用经费弥补
        /// </summary>
        public decimal Column3
        {
            get; set;
        }

        /// <summary>
        /// 上年结转
        /// </summary>
        public decimal Column4
        {
            get; set;
        }

        /// <summary>
        /// 支出合计
        /// </summary>
        public decimal Total3
        {
            get; set;
        }

        /// <summary>
        /// 对下供应小计
        /// </summary>
        public decimal Total4
        {
            get; set;
        }

        /// <summary>
        /// 预算外收入
        /// </summary>
        public decimal Column8
        {
            get; set;
        }

        /// <summary>
        /// 对下供应标准经费
        /// </summary>
        public decimal Column5
        {
            get; set;
        }

        /// <summary>
        /// 对下供应项目经费
        /// </summary>
        public decimal Column6
        {
            get; set;
        }

        /// <summary>
        /// 直接支出
        /// </summary>
        public decimal Column7
        {
            get; set;
        }

        /// <summary>
        /// 结转下半年
        /// </summary>
        public decimal Total5
        {
            get; set;
        }


    }
}