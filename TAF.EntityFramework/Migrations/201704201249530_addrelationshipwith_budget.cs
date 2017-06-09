namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrelationshipwith_budget : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BudgetOutlays", "ReceiptId");
            AddForeignKey("dbo.BudgetOutlays", "ReceiptId", "dbo.BudgetReceipts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BudgetOutlays", "ReceiptId", "dbo.BudgetReceipts");
            DropIndex("dbo.BudgetOutlays", new[] { "ReceiptId" });
        }
    }
}
