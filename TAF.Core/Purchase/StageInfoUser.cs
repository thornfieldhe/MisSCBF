namespace SCBF.Purchase
{
    using System;

    /// <summary>
    /// 阶段用户关联表
    /// </summary>
    public class StageInfoUser : TAFEntity
    {
        public Guid StageInfoId { get; set; }

        public Guid UserId { get; set; }
    }
}