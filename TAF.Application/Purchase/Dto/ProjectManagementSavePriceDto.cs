using System;

namespace SCBF.Purchase.Dto
{
    /// <summary>
    /// 采购过程管理编辑审定报价对象
    /// </summary>
    public class ProjectManagementSavePriceDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Price1
        /// </summary>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// HasPrint
        /// </summary>
        public int HasPrint
        {
            get; set;
        }

    }
}