namespace DataLayer.Migrations
{
    using DL.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Model1 context)
        {
            Roles role1 = new Roles { Id = 1, Name = "Administrator" };
            Roles role2 = new Roles { Id = 2, Name = "User" };
            Users user = new Users { Id = 1, Email = "adminWritersPlatform@mail.ru", Login = "admin", Password = "admin", IsDeleted = false, RoleId = role1.Id };
            Genres genre = new Genres { Id = 1, GenreName = "Action" };
            Books book = new Books { Id = 1, AuthorId = user.Id, AuthorName = user.Login, DatePublishing = DateTime.Now, GenreId = genre.Id, GenreName = genre.GenreName, Rating = 65, Text = "Ёто тестова€ книга, но ¬ы можете добавить свою, когда авторизуетесь.", Title = "“естова€ книга", RatingCount = 1, Respect = 0 };
            //Comments comment = new Comments { BooksId = book.Id, UserId = user.Id, UserLogin = user.Login, Text = "Testing Comments." };
            //Comments comment2 = new Comments { BooksId = book2.Id, UserId = user.Id, UserLogin = user.Login, Text = "Testing Comments.2" };
            //Comments comment3 = new Comments { BooksId = book2.Id, UserId = user.Id, UserLogin = user.Login, Text = "Testing Comments.3" };
            context.Roles.AddOrUpdate(role1);

            context.Users.AddOrUpdate(user);
            context.Genres.AddOrUpdate(genre);
            context.Books.AddOrUpdate(book);
            //context.Comments.AddOrUpdate(comment);
            //context.Comments.AddOrUpdate(comment2);
            //context.Comments.AddOrUpdate(comment3);
        }
    }
}
