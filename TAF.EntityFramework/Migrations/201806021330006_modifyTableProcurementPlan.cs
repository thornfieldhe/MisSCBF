namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTableProcurementPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlanWithBudgetOutlays", "Type", c => c.Int(nullable: false));
            AddColumn("dbo.ProcurementPlans", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProcurementPlans", "Year");
            DropColumn("dbo.ProcurementPlans", "Month");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcurementPlans", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.ProcurementPlans", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.ProcurementPlans", "Date");
            DropColumn("dbo.PlanWithBudgetOutlays", "Type");
        }
    }
}
