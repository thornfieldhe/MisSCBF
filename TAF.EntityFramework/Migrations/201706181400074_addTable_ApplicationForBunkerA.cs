namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_ApplicationForBunkerA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForBunkerAs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        OilCardId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AuditingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverId = c.Guid(),
                        AuditorId = c.Guid(),
                        Date = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.AuditorId)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.OilCards", t => t.OilCardId, cascadeDelete: true)
                .Index(t => t.OilCardId)
                .Index(t => t.DriverId)
                .Index(t => t.AuditorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForBunkerAs", "OilCardId", "dbo.OilCards");
            DropForeignKey("dbo.ApplicationForBunkerAs", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.ApplicationForBunkerAs", "AuditorId", "dbo.SysDictionaries");
            DropIndex("dbo.ApplicationForBunkerAs", new[] { "AuditorId" });
            DropIndex("dbo.ApplicationForBunkerAs", new[] { "DriverId" });
            DropIndex("dbo.ApplicationForBunkerAs", new[] { "OilCardId" });
            DropTable("dbo.ApplicationForBunkerAs");
        }
    }
}
