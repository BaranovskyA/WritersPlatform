namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Text", c => c.String());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "Text", c => c.String(maxLength: 1));
        }
    }
}
