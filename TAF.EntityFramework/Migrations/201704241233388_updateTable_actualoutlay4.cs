namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_actualoutlay4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActualOutlays", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActualOutlays", "Year");
        }
    }
}
