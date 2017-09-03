namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoucherAudit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VoucherAudits", "Point23", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point23Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point24", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point24Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point25", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point25Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point26", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point26Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point27", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point27Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point28", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point28Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point29", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point29Note", c => c.String());
            AddColumn("dbo.VoucherAudits", "Point30", c => c.Int(nullable: false));
            AddColumn("dbo.VoucherAudits", "Point30Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VoucherAudits", "Point30Note");
            DropColumn("dbo.VoucherAudits", "Point30");
            DropColumn("dbo.VoucherAudits", "Point29Note");
            DropColumn("dbo.VoucherAudits", "Point29");
            DropColumn("dbo.VoucherAudits", "Point28Note");
            DropColumn("dbo.VoucherAudits", "Point28");
            DropColumn("dbo.VoucherAudits", "Point27Note");
            DropColumn("dbo.VoucherAudits", "Point27");
            DropColumn("dbo.VoucherAudits", "Point26Note");
            DropColumn("dbo.VoucherAudits", "Point26");
            DropColumn("dbo.VoucherAudits", "Point25Note");
            DropColumn("dbo.VoucherAudits", "Point25");
            DropColumn("dbo.VoucherAudits", "Point24Note");
            DropColumn("dbo.VoucherAudits", "Point24");
            DropColumn("dbo.VoucherAudits", "Point23Note");
            DropColumn("dbo.VoucherAudits", "Point23");
        }
    }
}
