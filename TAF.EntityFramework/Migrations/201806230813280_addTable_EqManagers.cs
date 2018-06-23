namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_EqManagers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blacklists",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.Guid(nullable: false),
                        Type = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EqManagers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                        Unit1 = c.Guid(),
                        Score1 = c.Decimal(precision: 18, scale: 2),
                        Unit2 = c.Guid(),
                        Score2 = c.Decimal(precision: 18, scale: 2),
                        Unit3 = c.Guid(),
                        Score3 = c.Decimal(precision: 18, scale: 2),
                        Unit4 = c.Guid(),
                        Score4 = c.Decimal(precision: 18, scale: 2),
                        Unit5 = c.String(),
                        Score5 = c.Decimal(precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EqManagers");
            DropTable("dbo.Blacklists");
        }
    }
}
