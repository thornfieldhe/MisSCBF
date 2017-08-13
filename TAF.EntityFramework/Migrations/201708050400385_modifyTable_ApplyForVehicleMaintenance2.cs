namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_ApplyForVehicleMaintenance2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaintenanceDeliveries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplyForVehicleMaintenanceId = c.Guid(nullable: false),
                        DeliveryId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplyForVehicleMaintenances", t => t.ApplyForVehicleMaintenanceId, cascadeDelete: true)
                .Index(t => t.ApplyForVehicleMaintenanceId);
            
            CreateTable(
                "dbo.ManHours",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplyForVehicleMaintenanceId = c.Guid(nullable: false),
                        PartId = c.Guid(nullable: false),
                        ManHourId = c.Guid(nullable: false),
                        Hours1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hours2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplyForVehicleMaintenances", t => t.ApplyForVehicleMaintenanceId, cascadeDelete: true)
                .Index(t => t.ApplyForVehicleMaintenanceId);
            
            CreateTable(
                "dbo.ServicingMaterials",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ApplyForVehicleMaintenanceId = c.Guid(nullable: false),
                        PartId = c.Guid(nullable: false),
                        MaterialId = c.Guid(nullable: false),
                        Amount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplyForVehicleMaintenances", t => t.ApplyForVehicleMaintenanceId, cascadeDelete: true)
                .Index(t => t.ApplyForVehicleMaintenanceId);
            
            AddColumn("dbo.ApplyForVehicleMaintenances", "Note3", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServicingMaterials", "ApplyForVehicleMaintenanceId", "dbo.ApplyForVehicleMaintenances");
            DropForeignKey("dbo.ManHours", "ApplyForVehicleMaintenanceId", "dbo.ApplyForVehicleMaintenances");
            DropForeignKey("dbo.MaintenanceDeliveries", "ApplyForVehicleMaintenanceId", "dbo.ApplyForVehicleMaintenances");
            DropIndex("dbo.ServicingMaterials", new[] { "ApplyForVehicleMaintenanceId" });
            DropIndex("dbo.ManHours", new[] { "ApplyForVehicleMaintenanceId" });
            DropIndex("dbo.MaintenanceDeliveries", new[] { "ApplyForVehicleMaintenanceId" });
            DropColumn("dbo.ApplyForVehicleMaintenances", "Note3");
            DropTable("dbo.ServicingMaterials");
            DropTable("dbo.ManHours");
            DropTable("dbo.MaintenanceDeliveries");
        }
    }
}
