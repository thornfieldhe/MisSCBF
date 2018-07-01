namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_Equip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equips",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LayerId = c.Guid(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Equips");
        }
    }
}
