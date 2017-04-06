namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_sysDictionary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysDictionaries", "Value5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysDictionaries", "Value5");
        }
    }
}
