namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_attachment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attachments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Size = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Path = c.String(),
                        Ext = c.String(),
                        Category = c.String(),
                        ModuleId = c.Guid(nullable: false),
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
            DropTable("dbo.Attachments");
        }
    }
}
