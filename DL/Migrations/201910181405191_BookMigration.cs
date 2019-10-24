namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "RatingCount", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Respect", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Respect");
            DropColumn("dbo.Books", "RatingCount");
        }
    }
}
