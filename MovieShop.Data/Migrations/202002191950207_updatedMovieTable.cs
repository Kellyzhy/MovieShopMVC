namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMovieTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Movies", newName: "Movie");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Movie", newName: "Movies");
        }
    }
}
