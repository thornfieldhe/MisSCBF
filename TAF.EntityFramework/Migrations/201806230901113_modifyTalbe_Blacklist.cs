namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTalbe_Blacklist : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blacklists", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blacklists", "Name", c => c.Guid(nullable: false));
        }
    }
}
