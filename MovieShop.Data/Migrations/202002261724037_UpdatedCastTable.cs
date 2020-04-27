namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCastTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cast", "Name", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cast", "Name", c => c.String(maxLength: 128));
        }
    }
}
