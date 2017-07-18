namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_UploadOilCarRoofRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadOilCarRoofRelationships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RId = c.Guid(nullable: false),
                        OId = c.Guid(nullable: false),
                        Month = c.String(),
                        Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadOilCarRoofRelationships");
        }
    }
}
