namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_ApplyForVehicleMaintenance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyForVehicleMaintenances",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CarInfoId = c.Guid(nullable: false),
                        Killomiters = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverId = c.Guid(nullable: false),
                        Note = c.String(),
                        Note2 = c.String(),
                        Status = c.Int(nullable: false),
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
            DropForeignKey("dbo.ApplyForVehicleMaintenances", "CarInfoId", "dbo.CarInfoes");
            DropIndex("dbo.ApplyForVehicleMaintenances", new[] { "CarInfoId" });
            DropTable("dbo.ApplyForVehicleMaintenances");
        }
    }
}
