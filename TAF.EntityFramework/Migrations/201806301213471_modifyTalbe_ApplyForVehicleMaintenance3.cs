namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTalbe_ApplyForVehicleMaintenance3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyForVehicleMaintenances", "ServiceDepotId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyForVehicleMaintenances", "ServiceDepotId");
        }
    }
}
