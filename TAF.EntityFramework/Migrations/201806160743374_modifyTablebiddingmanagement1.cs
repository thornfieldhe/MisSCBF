namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyTablebiddingmanagement1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BiddingManagements", "HasPrint", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BiddingManagements", "HasPrint", c => c.Boolean(nullable: false));
        }
    }
}
