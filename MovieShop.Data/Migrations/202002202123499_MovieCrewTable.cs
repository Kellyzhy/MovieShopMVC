namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieCrewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew");
            DropIndex("dbo.Movie", new[] { "Crew_Id" });
            CreateTable(
                "dbo.MovieCrew",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CrewId = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 128),
                        Job = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CrewId, t.Department, t.Job })
                .ForeignKey("dbo.Crew", t => t.CrewId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CrewId);
            
            DropColumn("dbo.Movie", "Crew_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movie", "Crew_Id", c => c.Int());
            DropForeignKey("dbo.MovieCrew", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "CrewId", "dbo.Crew");
            DropIndex("dbo.MovieCrew", new[] { "CrewId" });
            DropIndex("dbo.MovieCrew", new[] { "MovieId" });
            DropTable("dbo.MovieCrew");
            CreateIndex("dbo.Movie", "Crew_Id");
            AddForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew", "Id");
        }
    }
}
