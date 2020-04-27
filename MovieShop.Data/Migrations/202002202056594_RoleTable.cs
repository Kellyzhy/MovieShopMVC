namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Movie_Id", c => c.Int());
            CreateIndex("dbo.User", "Movie_Id");
            AddForeignKey("dbo.User", "Movie_Id", "dbo.Movie", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Movie_Id", "dbo.Movie");
            DropIndex("dbo.User", new[] { "Movie_Id" });
            DropColumn("dbo.User", "Movie_Id");
            DropTable("dbo.Role");
        }
    }
}
