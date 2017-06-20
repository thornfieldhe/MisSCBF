namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTable_carinfo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarInfoes", "OctaneRatingId", c => c.Guid());
            DropColumn("dbo.CarInfoes", "Ylbh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarInfoes", "Ylbh", c => c.String());
            DropColumn("dbo.CarInfoes", "OctaneRatingId");
        }
    }
}
