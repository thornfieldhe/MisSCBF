namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editTable_ProjectManagement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectManagements", "Date2", c => c.DateTime());
            AlterColumn("dbo.ProjectManagements", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProjectManagements", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ProjectManagements", "Date2", c => c.DateTime(nullable: false));
        }
    }
}
