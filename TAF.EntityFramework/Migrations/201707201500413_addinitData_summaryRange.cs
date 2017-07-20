namespace SCBF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addinitData_summaryRange : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'653C65F0-0420-4F81-8B20-241ACE25AB8A', N'5', null, N'Car_OilWearSummary', N'10', null, null, null, null, null, null, null, N'2017-07-20 22:53:33.937', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'E03BADB0-276C-46F9-B1A1-2C7ABAAD2065', N'1', null, N'Car_OilWearWinter', N'4', null, null, null, null, null, null, null, N'2017-07-20 22:53:59.407', N'1', null, null, null, null, null, null, null, null, null, null, null, null)
INSERT INTO [dbo].[SysDictionaries] ([Id], [Value], [Note], [Category], [Value2], [Value3], [Value4], [Value5], [Value6], [Value7], [Value8], [Value9], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [Value10], [Value11], [Value12], [Value13], [Value14], [Value15], [Value16], [Value17], [Value18], [Value19]) VALUES (N'01BF3CAB-BA6F-42A0-9D26-355442EE0B27', N'11', null, N'Car_OilWearWinter', N'12', null, null, null, null, null, null, null, N'2017-07-20 22:53:54.637', N'1', null, null, null, null, null, null, null, null, null, null, null, null)");
        }
        
        public override void Down()
        {
        }
    }
}
