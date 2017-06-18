namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_oilcard : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OilCards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CarInfoId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarInfoes", t => t.CarInfoId, cascadeDelete: true)
                .Index(t => t.CarInfoId);
            
            CreateTable(
                "dbo.RechargeRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OilCardId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OilCards", t => t.OilCardId, cascadeDelete: true)
                .Index(t => t.OilCardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RechargeRecords", "OilCardId", "dbo.OilCards");
            DropForeignKey("dbo.OilCards", "CarInfoId", "dbo.CarInfoes");
            DropIndex("dbo.RechargeRecords", new[] { "OilCardId" });
            DropIndex("dbo.OilCards", new[] { "CarInfoId" });
            DropTable("dbo.RechargeRecords");
            DropTable("dbo.OilCards");
        }
    }
}
