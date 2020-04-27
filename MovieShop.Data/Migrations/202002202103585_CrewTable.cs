namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crew",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmdbUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "Crew_Id", c => c.Int());
            CreateIndex("dbo.Movie", "Crew_Id");
            AddForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movie", "Crew_Id", "dbo.Crew");
            DropIndex("dbo.Movie", new[] { "Crew_Id" });
            DropColumn("dbo.Movie", "Crew_Id");
            DropTable("dbo.Crew");
        }
    }
}
