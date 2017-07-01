namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_ApplicationForBunkerA1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationForBunkerAs", "ConfirmAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationForBunkerAs", "ConfirmAmount");
        }
    }
}
