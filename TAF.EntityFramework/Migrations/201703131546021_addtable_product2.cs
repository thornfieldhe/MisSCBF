namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_product2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Brand", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Brand");
        }
    }
}
