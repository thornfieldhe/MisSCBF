namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_actualoutlay2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActualOutlays", "OutlayId", c => c.Guid());
            CreateIndex("dbo.ActualOutlays", "OutlayId");
            AddForeignKey("dbo.ActualOutlays", "OutlayId", "dbo.BudgetOutlays", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActualOutlays", "OutlayId", "dbo.BudgetOutlays");
            DropIndex("dbo.ActualOutlays", new[] { "OutlayId" });
            DropColumn("dbo.ActualOutlays", "OutlayId");
        }
    }
}
