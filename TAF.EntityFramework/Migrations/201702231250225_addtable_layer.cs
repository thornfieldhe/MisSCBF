namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_layer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PId = c.Guid(),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        LevelCode = c.String(),
                        Note = c.String(),
                        Category = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SysDictionaries",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Value = c.String(),
                        Note = c.String(),
                        Category = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SysDictionaries");
            DropTable("dbo.Layers");
        }
    }
}
