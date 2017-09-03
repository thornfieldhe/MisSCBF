namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtable_InvoiceCheck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceChecks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        From = c.Long(nullable: false),
                        To = c.Long(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Long(nullable: false),
                        InvoiceCheckId = c.Guid(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InvoiceChecks", t => t.InvoiceCheckId, cascadeDelete: true)
                .Index(t => t.InvoiceCheckId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "InvoiceCheckId", "dbo.InvoiceChecks");
            DropIndex("dbo.Invoices", new[] { "InvoiceCheckId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceChecks");
        }
    }
}
