namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miodifyTable_PerformanceAmountDetail3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PerformanceAmountDetails", "Department", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PerformanceAmountDetails", "Department");
        }
    }
}
