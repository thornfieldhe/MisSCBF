namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateRelationship_hisstock : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.HisStocks", "StorageId");
            AddForeignKey("dbo.HisStocks", "StorageId", "dbo.SysDictionaries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HisStocks", "StorageId", "dbo.SysDictionaries");
            DropIndex("dbo.HisStocks", new[] { "StorageId" });
        }
    }
}
