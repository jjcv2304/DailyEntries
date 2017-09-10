namespace DailyEntry.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdataDairyTableNameToDaily : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tblDiaryFeeling", newName: "tblDailyFeeling");
            RenameColumn(table: "dbo.tblDailyFeeling", name: "DiaryFeelingId", newName: "DailyFeelingId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.tblDailyFeeling", name: "DailyFeelingId", newName: "DiaryFeelingId");
            RenameTable(name: "dbo.tblDailyFeeling", newName: "tblDiaryFeeling");
        }
    }
}
