namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_product6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Unit2");
            DropColumn("dbo.Products", "UnitConversion");
            DropColumn("dbo.Products", "Color");
            DropColumn("dbo.Products", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Brand", c => c.String());
            AddColumn("dbo.Products", "Color", c => c.String());
            AddColumn("dbo.Products", "UnitConversion", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Unit2", c => c.String());
        }
    }
}
