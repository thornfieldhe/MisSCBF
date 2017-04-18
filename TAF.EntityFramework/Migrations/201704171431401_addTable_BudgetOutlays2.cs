namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_BudgetOutlays2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BudgetOutlays", "Column2", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BudgetOutlays", "Column31");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BudgetOutlays", "Column31", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BudgetOutlays", "Column2");
        }
    }
}
