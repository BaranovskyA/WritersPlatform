namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "UserLogin", c => c.String());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "UserLogin");
            DropColumn("dbo.Comments", "UserId");
        }
    }
}
