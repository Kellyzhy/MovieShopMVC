namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MocieTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 5, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
