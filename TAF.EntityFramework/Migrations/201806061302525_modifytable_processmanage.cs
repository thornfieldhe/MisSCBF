namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_processmanage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProcessManagements", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProcessManagements", "Year");
        }
    }
}
