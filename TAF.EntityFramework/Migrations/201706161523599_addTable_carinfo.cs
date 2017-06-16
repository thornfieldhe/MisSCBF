namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_carinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Clxh = c.String(),
                        Cjh = c.String(),
                        Fdjh = c.String(),
                        Ylbh = c.String(),
                        Cph = c.String(),
                        Jcgls = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zbsj = c.DateTime(nullable: false),
                        Zbzl = c.String(),
                        Xszh = c.String(),
                        Yxxe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClzkId = c.Guid(nullable: false),
                        DriverId = c.Guid(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.ClzkId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.ClzkId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        SoldierId = c.String(),
                        ValidDrivingLicense = c.DateTime(nullable: false),
                        DrivingLicense = c.String(),
                        LevelId = c.Guid(nullable: false),
                        PhoneNumber = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "LevelId", "dbo.SysDictionaries");
            DropForeignKey("dbo.CarInfoes", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.CarInfoes", "ClzkId", "dbo.SysDictionaries");
            DropIndex("dbo.Drivers", new[] { "LevelId" });
            DropIndex("dbo.CarInfoes", new[] { "DriverId" });
            DropIndex("dbo.CarInfoes", new[] { "ClzkId" });
            DropTable("dbo.Drivers");
            DropTable("dbo.CarInfoes");
        }
    }
}
