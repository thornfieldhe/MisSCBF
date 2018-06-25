namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_blacklist2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blacklists", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blacklists", "Year");
        }
    }
}
