namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrailerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trailer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        TraileraUrl = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailer", "MovieId", "dbo.Movie");
            DropIndex("dbo.Trailer", new[] { "MovieId" });
            DropTable("dbo.Trailer");
        }
    }
}
