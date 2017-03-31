namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_stock3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliveries", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Entries", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Stocks", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stocks", "Price");
            DropColumn("dbo.Entries", "Price");
            DropColumn("dbo.Deliveries", "Price");
        }
    }
}
