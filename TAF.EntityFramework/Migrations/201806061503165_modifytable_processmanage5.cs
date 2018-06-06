namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_processmanage5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProcessManagements", "ProcurementPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcessManagements", "ProcurementPlanId", c => c.Guid(nullable: false));
        }
    }
}
