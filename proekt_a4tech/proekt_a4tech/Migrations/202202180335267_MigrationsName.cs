namespace proekt_a4tech.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationsName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        SportKindId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SportKinds", t => t.SportKindId, cascadeDelete: true)
                .Index(t => t.SportKindId);
            
            CreateTable(
                "dbo.SportKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(maxLength: 200),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Judges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullNname = c.String(maxLength: 200),
                        Category = c.String(),
                        Experience = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Record = c.String(maxLength: 100),
                        SportsmanId = c.Int(nullable: false),
                        SportKindId = c.Int(nullable: false),
                        CategorynId = c.Int(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.SportKinds", t => t.SportKindId, cascadeDelete: true)
                .ForeignKey("dbo.Sportsmen", t => t.SportsmanId, cascadeDelete: true)
                .Index(t => t.SportsmanId)
                .Index(t => t.SportKindId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Sportsmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullNname = c.String(maxLength: 200),
                        Birthday = c.DateTime(nullable: false),
                        Sex = c.Int(nullable: false),
                        Weight = c.Single(nullable: false),
                        Disability = c.Boolean(nullable: false),
                        NationalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nationalities", t => t.NationalityId, cascadeDelete: true)
                .Index(t => t.NationalityId);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 200),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JudgeCompetitions",
                c => new
                    {
                        Judge_Id = c.Int(nullable: false),
                        Competition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Judge_Id, t.Competition_Id })
                .ForeignKey("dbo.Judges", t => t.Judge_Id, cascadeDelete: true)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id, cascadeDelete: true)
                .Index(t => t.Judge_Id)
                .Index(t => t.Competition_Id);
            
            CreateTable(
                "dbo.ResultCompetitions",
                c => new
                    {
                        Result_Id = c.Int(nullable: false),
                        Competition_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Result_Id, t.Competition_Id })
                .ForeignKey("dbo.Results", t => t.Result_Id, cascadeDelete: true)
                .ForeignKey("dbo.Competitions", t => t.Competition_Id, cascadeDelete: true)
                .Index(t => t.Result_Id)
                .Index(t => t.Competition_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "SportsmanId", "dbo.Sportsmen");
            DropForeignKey("dbo.Sportsmen", "NationalityId", "dbo.Nationalities");
            DropForeignKey("dbo.Results", "SportKindId", "dbo.SportKinds");
            DropForeignKey("dbo.ResultCompetitions", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.ResultCompetitions", "Result_Id", "dbo.Results");
            DropForeignKey("dbo.Results", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.JudgeCompetitions", "Competition_Id", "dbo.Competitions");
            DropForeignKey("dbo.JudgeCompetitions", "Judge_Id", "dbo.Judges");
            DropForeignKey("dbo.Categories", "SportKindId", "dbo.SportKinds");
            DropIndex("dbo.ResultCompetitions", new[] { "Competition_Id" });
            DropIndex("dbo.ResultCompetitions", new[] { "Result_Id" });
            DropIndex("dbo.JudgeCompetitions", new[] { "Competition_Id" });
            DropIndex("dbo.JudgeCompetitions", new[] { "Judge_Id" });
            DropIndex("dbo.Sportsmen", new[] { "NationalityId" });
            DropIndex("dbo.Results", new[] { "Category_Id" });
            DropIndex("dbo.Results", new[] { "SportKindId" });
            DropIndex("dbo.Results", new[] { "SportsmanId" });
            DropIndex("dbo.Categories", new[] { "SportKindId" });
            DropTable("dbo.ResultCompetitions");
            DropTable("dbo.JudgeCompetitions");
            DropTable("dbo.Employees");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Sportsmen");
            DropTable("dbo.Results");
            DropTable("dbo.Judges");
            DropTable("dbo.Competitions");
            DropTable("dbo.SportKinds");
            DropTable("dbo.Categories");
        }
    }
}
