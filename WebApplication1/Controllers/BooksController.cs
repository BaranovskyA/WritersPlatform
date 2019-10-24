using BusinessLayer.Utils;
using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;
using System.IO;
using WebApplication1.Filters;
using BusinessLayer;
using System.Web.UI.HtmlControls;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        IBookService bookService;
        ICommentService commentService;
        IGenreService genreService;
        IUserService userService;
        public BooksController(IBookService serv, ICommentService serv2, IGenreService serv3, IUserService serv4)
        {
            bookService = serv;
            commentService = serv2;
            genreService = serv3;
            userService = serv4;
        }

        public ActionResult Index()
        {
            List<GenreModel> genres = AutoMapper<IEnumerable<BGenre>, List<GenreModel>>.Map(genreService.GetGenres);
            GenreModel genre = new GenreModel() { Id = 0, GenreName = "All" };
            genres.Add(genre);
            ViewBag.genre = new SelectList(genres, "Id", "GenreName");
            return View(AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks));
        }

        public ActionResult BookPage(int id)
        {
            BookModel book = AutoMapper<BBook, BookModel>.Map(bookService.GetBook, (int)id);
            IEnumerable<CommentModel> comments = AutoMapper<IEnumerable<BComment>, List<CommentModel>>.Map(commentService.GetComments);
            List<CommentModel> bookComment = new List<CommentModel>();
            foreach (var item in comments)
            {
                if (item.BooksId == book.Id) bookComment.Add(item);
            }
            ViewBag.Comments = bookComment;
            return View(book);
        }

        public ActionResult SurveyIndex()
        {
            return View(AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks));
        }

        public ActionResult AddRating(int id, int rating)
        {
            BookModel book = AutoMapper<BBook, BookModel>.Map(bookService.GetBook(id));
            book.RatingCount += 1;
            book.Rating = (book.Rating + rating) / book.RatingCount;
            BBook editBook = AutoMapper<BBook, BBook>.Map(bookService.GetBook(book.Id));
            bookService.CreateOrUpdate(editBook);
            return View(book);
        }

        public ActionResult CreateAndEdit(int? id=0)
        {
            BookModel book = new BookModel();
            List<GenreModel> genres = AutoMapper<IEnumerable<BGenre>, List<GenreModel>>.Map(genreService.GetGenres);
            ViewBag.GenreId = new SelectList(genres, "Id", "GenreName");
            if (id != 0)
            {
                book = AutoMapper<BBook, BookModel>.Map(bookService.GetBook,(int)id);
            }          
            return PartialView("CreateAndEdit", book);
        }

        [Logger]
        [HttpPost]
        public ActionResult CreateAndEdit(BookModel book)
        {
            BBook newBook = AutoMapper<BookModel, BBook>.Map(book);
            List<UserModel> users = AutoMapper<IEnumerable<BUsers>, List<UserModel>>.Map(userService.GetUsers);
            users.Where(x => x.Login == Request.Cookies["auth_cookie"].Value);
            var user = userService.GetUserByLogin(HttpContext.Request.Cookies["authCookie"].Value);
            newBook.AuthorId = user.Id;
            if(bookService.GetBooks().Where(x=>x.AuthorId == user.Id).Count() < 3) bookService.CreateOrUpdate(newBook);
            return PartialView("ViewBooks", AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks));
        }

        [HttpPost]
        public ActionResult SortGenre(int? id=0)
        {
            if (id == 0)
                return PartialView("ViewBooks", AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks));
            else 
                return PartialView("ViewBooks", AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooksSortGenre, (int)id));
        }

        [Logger]
        public ActionResult Delete(int id)
        {
            bookService.DeleteBook(id);
            return PartialView("ViewBooks", AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks));
        }
    }
}
