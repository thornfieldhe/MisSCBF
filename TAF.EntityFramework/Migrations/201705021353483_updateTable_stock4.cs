namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_stock4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Deliveries", "Unit");
            DropColumn("dbo.Entries", "Unit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entries", "Unit", c => c.String());
            AddColumn("dbo.Deliveries", "Unit", c => c.String());
        }
    }
}
