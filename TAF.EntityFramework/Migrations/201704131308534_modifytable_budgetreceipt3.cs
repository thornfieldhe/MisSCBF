namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_budgetreceipt3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgetReceipts", "FileId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BudgetReceipts", "FileId");
        }
    }
}
