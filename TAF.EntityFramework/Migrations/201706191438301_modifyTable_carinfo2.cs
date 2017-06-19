namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTable_carinfo2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarInfoes", "OilWearSummer", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.CarInfoes", "OilWearWinter", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarInfoes", "OilWearWinter");
            DropColumn("dbo.CarInfoes", "OilWearSummer");
        }
    }
}
