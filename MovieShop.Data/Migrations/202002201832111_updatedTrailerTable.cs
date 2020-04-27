namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTrailerTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trailer", "TraileraUrl", c => c.String(maxLength: 2084));
            AlterColumn("dbo.Trailer", "Name", c => c.String(maxLength: 2084));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trailer", "Name", c => c.String());
            AlterColumn("dbo.Trailer", "TraileraUrl", c => c.String());
        }
    }
}
