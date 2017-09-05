namespace DailyEntry.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDiaryFeeling",
                c => new
                    {
                        DiaryFeelingId = c.Int(nullable: false, identity: true),
                        Sleep = c.Int(nullable: false),
                        Fatigue = c.Int(nullable: false),
                        Stress = c.Int(nullable: false),
                        Soreness = c.Int(nullable: false),
                        Notes = c.String(),
                        Date = c.DateTime(nullable: false),
                        RestingHeartRate = c.Int(),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        DiaryuserId = c.Int(),
                    })
                .PrimaryKey(t => t.DiaryFeelingId)
                .ForeignKey("dbo.DiaryUsers", t => t.DiaryuserId)
                .Index(t => t.DiaryuserId);
            
            CreateTable(
                "dbo.tblWorkout",
                c => new
                    {
                        WorkoutId = c.Int(nullable: false, identity: true),
                        WorkoutTypeId = c.Int(nullable: false),
                        Distance = c.Decimal(precision: 18, scale: 2),
                        TotalTime = c.Time(),
                        Notes = c.String(),
                        DiaryFeelingId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkoutId)
                .ForeignKey("dbo.tblDiaryFeeling", t => t.DiaryFeelingId)
                .ForeignKey("dbo.tblWorkoutType", t => t.WorkoutTypeId, cascadeDelete: true)
                .Index(t => t.DiaryFeelingId)
                .Index(t => t.WorkoutTypeId);
            
            CreateTable(
                "dbo.tblWorkoutType",
                c => new
                    {
                        WorkoutTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutTypeId);
            
            CreateTable(
                "dbo.DiaryUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Apiuser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Secret = c.String(),
                        AppId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthToken",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Expiration = c.DateTime(nullable: false),
                        ApiUser_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apiuser", t => t.ApiUser_Id, cascadeDelete: true)
                .Index(t => t.ApiUser_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AuthToken", new[] { "ApiUser_Id" });
            DropIndex("dbo.tblWorkout", new[] { "WorkoutTypeId" });
            DropIndex("dbo.tblWorkout", new[] { "DiaryFeelingId" });
            DropIndex("dbo.tblDiaryFeeling", new[] { "DiaryuserId" });
            DropForeignKey("dbo.AuthToken", "ApiUser_Id", "dbo.Apiuser");
            DropForeignKey("dbo.tblWorkout", "WorkoutTypeId", "dbo.tblWorkoutType");
            DropForeignKey("dbo.tblWorkout", "DiaryFeelingId", "dbo.tblDiaryFeeling");
            DropForeignKey("dbo.tblDiaryFeeling", "DiaryuserId", "dbo.DiaryUsers");
            DropTable("dbo.AuthToken");
            DropTable("dbo.Apiuser");
            DropTable("dbo.DiaryUsers");
            DropTable("dbo.tblWorkoutType");
            DropTable("dbo.tblWorkout");
            DropTable("dbo.tblDiaryFeeling");
        }
    }
}
