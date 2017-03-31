namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTableSysDictionaries : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysDictionaries", "Value2", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value3", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysDictionaries", "Value4");
            DropColumn("dbo.SysDictionaries", "Value3");
            DropColumn("dbo.SysDictionaries", "Value2");
        }
    }
}
