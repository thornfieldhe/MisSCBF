namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable_VoucherAudit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VoucherAudits",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Point1 = c.Int(nullable: false),
                        Point1Note = c.String(),
                        Point2 = c.Int(nullable: false),
                        Point2Note = c.String(),
                        Point3 = c.Int(nullable: false),
                        Point3Note = c.String(),
                        Point4 = c.Int(nullable: false),
                        Point4Note = c.String(),
                        Point5 = c.Int(nullable: false),
                        Point5Note = c.String(),
                        Point6 = c.Int(nullable: false),
                        Point6Note = c.String(),
                        Point7 = c.Int(nullable: false),
                        Point7Note = c.String(),
                        Point8 = c.Int(nullable: false),
                        Point8Note = c.String(),
                        Point9 = c.Int(nullable: false),
                        Point9Note = c.String(),
                        Point10 = c.Int(nullable: false),
                        Point10Note = c.String(),
                        Point11 = c.Int(nullable: false),
                        Point11Note = c.String(),
                        Point12 = c.Int(nullable: false),
                        Point12Note = c.String(),
                        Point13 = c.Int(nullable: false),
                        Point13Note = c.String(),
                        Point14 = c.Int(nullable: false),
                        Point14Note = c.String(),
                        Point15 = c.Int(nullable: false),
                        Point15Note = c.String(),
                        Point16 = c.Int(nullable: false),
                        Point16Note = c.String(),
                        Point17 = c.Int(nullable: false),
                        Point17Note = c.String(),
                        Point18 = c.Int(nullable: false),
                        Point18Note = c.String(),
                        Point19 = c.Int(nullable: false),
                        Point19Note = c.String(),
                        Point20 = c.Int(nullable: false),
                        Point20Note = c.String(),
                        Point21 = c.Int(nullable: false),
                        Point21Note = c.String(),
                        Point22 = c.Int(nullable: false),
                        Point22Note = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VoucherAudits");
        }
    }
}
