namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_PerformanceManage3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BidOpeningManagements", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.PerformanceAmountDetails", "PerformanceManageId", c => c.Guid(nullable: false));
            AddColumn("dbo.PerformanceAmountDetails", "User", c => c.String());
            AddColumn("dbo.PerformanceAmountDetails", "Phone", c => c.String());
            AddColumn("dbo.PerformanceManages", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.PerformanceAmountDetails", "PerformanceId");
            DropColumn("dbo.PerformanceManages", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PerformanceManages", "Note", c => c.String());
            AddColumn("dbo.PerformanceAmountDetails", "PerformanceId", c => c.Guid(nullable: false));
            DropColumn("dbo.PerformanceManages", "Date");
            DropColumn("dbo.PerformanceAmountDetails", "Phone");
            DropColumn("dbo.PerformanceAmountDetails", "User");
            DropColumn("dbo.PerformanceAmountDetails", "PerformanceManageId");
            DropColumn("dbo.BidOpeningManagements", "Date");
        }
    }
}
