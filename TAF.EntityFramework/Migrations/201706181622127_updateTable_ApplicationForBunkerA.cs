namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_ApplicationForBunkerA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationForBunkerAs", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationForBunkerAs", "Note");
        }
    }
}
