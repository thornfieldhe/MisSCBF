namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 阶段实际支出关联表
    /// </summary>
    public class StageInfoActualOutlay : TAFEntity
    {
        public Guid StageInfoId { get; set; }

        public Guid ActualOutlayId { get; set; }
    }
}