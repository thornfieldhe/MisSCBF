namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_CarOil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarOils",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarInfoId = c.Guid(nullable: false),
                        Kilometres = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarInfoes", t => t.CarInfoId, cascadeDelete: true)
                .Index(t => t.CarInfoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarOils", "CarInfoId", "dbo.CarInfoes");
            DropIndex("dbo.CarOils", new[] { "CarInfoId" });
            DropTable("dbo.CarOils");
        }
    }
}
