namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_ApplicationForBunkerB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForBunkerBs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        OctaneStoreId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuditingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverId = c.Guid(),
                        AuditorId = c.Guid(),
                        CarInfoId = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.AuditorId)
                .ForeignKey("dbo.CarInfoes", t => t.CarInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.OctaneStores", t => t.OctaneStoreId, cascadeDelete: true)
                .Index(t => t.OctaneStoreId)
                .Index(t => t.DriverId)
                .Index(t => t.AuditorId)
                .Index(t => t.CarInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForBunkerBs", "OctaneStoreId", "dbo.OctaneStores");
            DropForeignKey("dbo.ApplicationForBunkerBs", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.ApplicationForBunkerBs", "CarInfoId", "dbo.CarInfoes");
            DropForeignKey("dbo.ApplicationForBunkerBs", "AuditorId", "dbo.SysDictionaries");
            DropIndex("dbo.ApplicationForBunkerBs", new[] { "CarInfoId" });
            DropIndex("dbo.ApplicationForBunkerBs", new[] { "AuditorId" });
            DropIndex("dbo.ApplicationForBunkerBs", new[] { "DriverId" });
            DropIndex("dbo.ApplicationForBunkerBs", new[] { "OctaneStoreId" });
            DropTable("dbo.ApplicationForBunkerBs");
        }
    }
}
