namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_unitPool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnitPools",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Category = c.String(),
                        ItemId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnitPools");
        }
    }
}
