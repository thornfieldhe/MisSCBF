namespace SCBF.Finance
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// 发票表
    /// </summary>
    public class Invoice : TAFEntity
    {

        public string Code { get; set; }

        public Guid InvoiceCheckId { get; set; }

        public virtual InvoiceCheck InvoiceCheck { get; set; }

    }
}