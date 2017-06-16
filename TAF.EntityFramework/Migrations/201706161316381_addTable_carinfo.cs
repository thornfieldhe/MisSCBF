namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_carinfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Clxh = c.String(),
                        Cjh = c.String(),
                        Fdjh = c.String(),
                        Ylbh = c.String(),
                        Cph = c.String(),
                        Jcgls = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Zbsj = c.DateTime(nullable: false),
                        Zbzl = c.String(),
                        Xszh = c.String(),
                        Yxxe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClzkId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SysDictionaries", t => t.ClzkId, cascadeDelete: true)
                .Index(t => t.ClzkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarInfoes", "ClzkId", "dbo.SysDictionaries");
            DropIndex("dbo.CarInfoes", new[] { "ClzkId" });
            DropTable("dbo.CarInfoes");
        }
    }
}
