// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceCheck.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   发票检查表
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SCBF.Finance
{
    using System.Collections.Generic;

    /// <summary>
    /// 发票检查表
    /// </summary>
    public class InvoiceCheck : TAFEntity
    {
        public long From { get; set; }

        public long To { get; set; }

        public virtual List<Invoice> Invoices { get; set; }
    }
}