namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTableProcurementPlan2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcurementPlans", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcurementPlans", "Type");
        }
    }
}
