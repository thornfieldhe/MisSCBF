namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_OilCardProofs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OilCardProofs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Month = c.String(),
                        BunkerACode = c.String(),
                        Date = c.String(),
                        Ss = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Msjg = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardNo = c.String(),
                        Clxh = c.String(),
                        Cph = c.String(),
                        Sy = c.String(),
                        Yyje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Jyje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Syje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ylbh = c.String(),
                        Jsy = c.String(),
                        Note = c.String(),
                        Status = c.Int(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UploadOilCardRoofs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Month = c.String(),
                        CarCode = c.String(),
                        AmountOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadOilCardRoofs");
            DropTable("dbo.OilCardProofs");
        }
    }
}
