namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifytable_uploadoilcardroof : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UploadOilCardRoofs", "FileId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UploadOilCardRoofs", "FileId");
        }
    }
}
