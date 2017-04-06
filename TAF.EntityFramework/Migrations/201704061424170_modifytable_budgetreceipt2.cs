namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_budgetreceipt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgetReceipts", "Column37", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BudgetReceipts", "Note37", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BudgetReceipts", "Note37");
            DropColumn("dbo.BudgetReceipts", "Column37");
        }
    }
}
