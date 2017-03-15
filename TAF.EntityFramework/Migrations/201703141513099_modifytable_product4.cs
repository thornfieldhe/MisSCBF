namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_product4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Order", c => c.String());
        }
    }
}
