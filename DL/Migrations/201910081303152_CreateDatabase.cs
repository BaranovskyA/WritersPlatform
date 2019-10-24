namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(maxLength: 100),
                    Text = c.String(maxLength: 100000000),
                    AuthorName = c.String(maxLength: 50),
                    GenreName = c.String(maxLength: 50),
                    AuthorId = c.Int(nullable: false),
                    GenreId = c.Int(nullable: false),
                    DatePublishing = c.DateTime(),
                    Rating = c.Int(),
                    Genres_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genres_Id)
                .Index(t => t.Genres_Id);

            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    GenreName = c.String(maxLength: 50),
                })
                .PrimaryKey(t => t.Id);

            //CreateTable(
            //    "dbo.__MigrationHistory",
            //    c => new
            //    {
            //        MigrationId = c.String(nullable: false, maxLength: 150),
            //        ContextKey = c.String(nullable: false, maxLength: 300),
            //        Model = c.Binary(nullable: false),
            //        ProductVersion = c.String(nullable: false, maxLength: 32),
            //    })
            //    .PrimaryKey(t => new { t.MigrationId, t.ContextKey });

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BooksId = c.Int(nullable: false),
                    Text = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => new { t.Id, t.BooksId });

            CreateTable(
                "dbo.LogDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Message = c.String(),
                    ControllerName = c.String(),
                    ActionName = c.String(),
                    StackTrace = c.String(),
                    Date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Login = c.String(maxLength: 50),
                    Password = c.String(maxLength: 50),
                    Email = c.String(maxLength: 50),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "GenreId", c => c.Int(nullable: false));

        }

        public override void Down()
        {
            DropForeignKey("dbo.Books", "Genres_Id", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "Genres_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.LogDetails");
            DropTable("dbo.Comments");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
            AlterColumn("dbo.Books", "GenreId", c => c.Int());
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
        }
    }
}
