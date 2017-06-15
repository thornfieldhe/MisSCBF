namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_sysdictionary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SysDictionaries", "Value10", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value11", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value12", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value13", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value14", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value15", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value16", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value17", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value18", c => c.String());
            AddColumn("dbo.SysDictionaries", "Value19", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SysDictionaries", "Value19");
            DropColumn("dbo.SysDictionaries", "Value18");
            DropColumn("dbo.SysDictionaries", "Value17");
            DropColumn("dbo.SysDictionaries", "Value16");
            DropColumn("dbo.SysDictionaries", "Value15");
            DropColumn("dbo.SysDictionaries", "Value14");
            DropColumn("dbo.SysDictionaries", "Value13");
            DropColumn("dbo.SysDictionaries", "Value12");
            DropColumn("dbo.SysDictionaries", "Value11");
            DropColumn("dbo.SysDictionaries", "Value10");
        }
    }
}
