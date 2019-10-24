using BusinessLayer.Utils;
using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL.Entities;

namespace BusinessLayer.Services
{
    public class BookService:IBookService
    {
        IUnitOfWork Database { get; set; }

        public BookService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateOrUpdate(BBook book)
        {
            if (book.Id == 0)
            {

                Books dbook = new Books() { AuthorId=book.AuthorId, Title = book.Title, GenreId=book.GenreId, DatePublishing = book.DatePublishing, AuthorName = book.AuthorName, GenreName = book.GenreName, Rating = book.Rating, Text = book.Text, Genres_Id = book.Genres_Id};
                Database.Books.Create(dbook);
            }
            else
            {
                Books editBook = AutoMapper<BBook, Books>.Map(book);
                Database.Books.Update(editBook);
            }
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BBook GetBook(int id)
        {
            if (id != 0)
            {
                BBook book = AutoMapper<Books, BBook>.Map(Database.Books.Get,(int)id);
                book.AuthorName = Database.Users.Get(book.AuthorId).Login;
                book.GenreName = Database.Genres.Get(book.GenreId).GenreName;
                return book;
            }
            return null;
        }

        public IEnumerable<BBook> GetBooks()
        {
            List<BBook> books =  AutoMapper<IEnumerable<Books>, List<BBook>>.Map(Database.Books.GetAll).ToList();
            books.ForEach(i => i.AuthorName = Database.Users.Get(i.AuthorId).Login);
            books.ForEach(i => i.GenreName = Database.Genres.Get(i.GenreId).GenreName);
            return books;
        }

        public IEnumerable<BBook> GetBooksSortGenre(int id)
        {
            List<BBook> books = AutoMapper<IEnumerable<Books>, List<BBook>>.Map(Database.Books.Find(i=>i.GenreId==id)).ToList();
            books.ForEach(i => i.AuthorName = Database.Users.Get(i.AuthorId).Login);
            books.ForEach(i => i.GenreName = Database.Genres.Get(i.GenreId).GenreName);
            return books;
        }

        public void DeleteBook(int id)
        {
            Database.Books.Delete(id);
            Database.Save();
        }

    }
}
