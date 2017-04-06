namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_budgetreceipt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BudgetReceipts", "Column1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column21", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column22", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column31", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column32", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column33", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column34", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column35", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column36", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column41", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column42", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column43", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column44", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column45", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column46", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column47", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.BudgetReceipts", "Column5", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BudgetReceipts", "Column5", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column47", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column46", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column45", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column44", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column43", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column42", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column41", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column36", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column35", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column34", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column33", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column32", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column31", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column22", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column21", c => c.String());
            AlterColumn("dbo.BudgetReceipts", "Column1", c => c.String());
        }
    }
}
