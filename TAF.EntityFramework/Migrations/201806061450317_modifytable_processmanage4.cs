namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_processmanage4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProcurementPlans", "ProcessManagement_Id", "dbo.ProcessManagements");
            DropIndex("dbo.ProcurementPlans", new[] { "ProcessManagement_Id" });
            DropColumn("dbo.ProcurementPlans", "ProcessManagement_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcurementPlans", "ProcessManagement_Id", c => c.Guid());
            CreateIndex("dbo.ProcurementPlans", "ProcessManagement_Id");
            AddForeignKey("dbo.ProcurementPlans", "ProcessManagement_Id", "dbo.ProcessManagements", "Id");
        }
    }
}
