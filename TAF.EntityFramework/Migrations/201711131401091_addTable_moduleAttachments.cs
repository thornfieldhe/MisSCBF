namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_moduleAttachments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModuleIdAttachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ModuleId = c.Guid(nullable: false),
                        AttachmentId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Attachments", "ModuleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attachments", "ModuleId", c => c.Guid(nullable: false));
            DropTable("dbo.ModuleIdAttachments");
        }
    }
}
