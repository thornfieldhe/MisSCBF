namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipwith_budget : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgetOutlays", "BudgetReceipt_Id", c => c.Guid());
            CreateIndex("dbo.BudgetOutlays", "BudgetReceipt_Id");
            AddForeignKey("dbo.BudgetOutlays", "BudgetReceipt_Id", "dbo.BudgetReceipts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetOutlays", "BudgetReceipt_Id", "dbo.BudgetReceipts");
            DropIndex("dbo.BudgetOutlays", new[] { "BudgetReceipt_Id" });
            DropColumn("dbo.BudgetOutlays", "BudgetReceipt_Id");
        }
    }
}
