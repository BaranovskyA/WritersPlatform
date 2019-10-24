namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", "Id");
            //CreateIndex("dbo.Comments", "BooksId");
            //AddForeignKey("dbo.Comments", "BooksId", "dbo.Books", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BooksId", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "BooksId" });
            DropPrimaryKey("dbo.Comments");
            AddPrimaryKey("dbo.Comments", new[] { "Id", "BooksId" });
        }
    }
}
