namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_actualoutlay3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActualOutlays", "FileId", c => c.Guid(nullable: false));
            AlterColumn("dbo.BudgetOutlays", "FileId", c => c.Guid(nullable: false));
            AlterColumn("dbo.BudgetReceipts", "FileId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BudgetReceipts", "FileId", c => c.String());
            AlterColumn("dbo.BudgetOutlays", "FileId", c => c.String());
            DropColumn("dbo.ActualOutlays", "FileId");
        }
    }
}
