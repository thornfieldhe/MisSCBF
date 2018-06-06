namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_processmanage3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProcessManagements", "Id", "dbo.ProcurementPlans");
            DropIndex("dbo.ProcessManagements", new[] { "Id" });
            AddColumn("dbo.ProcurementPlans", "ProcessManagement_Id", c => c.Guid());
            CreateIndex("dbo.ProcurementPlans", "ProcessManagement_Id");
            AddForeignKey("dbo.ProcurementPlans", "ProcessManagement_Id", "dbo.ProcessManagements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProcurementPlans", "ProcessManagement_Id", "dbo.ProcessManagements");
            DropIndex("dbo.ProcurementPlans", new[] { "ProcessManagement_Id" });
            DropColumn("dbo.ProcurementPlans", "ProcessManagement_Id");
            CreateIndex("dbo.ProcessManagements", "Id");
            AddForeignKey("dbo.ProcessManagements", "Id", "dbo.ProcurementPlans", "Id");
        }
    }
}
