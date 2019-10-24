using AutoMapper;
using BusinessLayer;
using BusinessLayer.BInterfaces;
using BusinessLayer.BModel;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        ICommentService commentService;
        IBookService bookService;
        IUserService userService;
        static LogDetailService log;
        public CommentController(ICommentService serv, ILogDetailService serv2, IBookService serv3, IUserService serv4)
        {
            commentService = serv;
            log = (LogDetailService)serv2;
            bookService = serv3;
            userService = serv4;
        }

        [Logger]
        [HttpPost]
        public ActionResult EditAndCreate(CommentModel comment)
        {
            BComment oldComment = AutoMapper<CommentModel, BComment>.Map(comment);
            List<UserModel> users = AutoMapper<IEnumerable<BUsers>, List<UserModel>>.Map(userService.GetUsers);
            users.Where(x => x.Login == Request.Cookies["auth_cookie"].Value);
            var user = userService.GetUserByLogin(HttpContext.Request.Cookies["authCookie"].Value);
            oldComment.UserId = user.Id;
            commentService.Create(oldComment);
            BookModel book = AutoMapper<BBook, BookModel>.Map(bookService.GetBook(oldComment.BooksId));
            book.Respect += 2;
            return View("Index", AutoMapper<IEnumerable<BComment>, List<CommentModel>>.Map(commentService.GetComments));
        }
        [Logger]
        public ActionResult Delete(int id)
        {
            commentService.DeleteComment(id);
            return PartialView("ViewAuthors", AutoMapper<IEnumerable<BComment>, List<CommentModel>>.Map(commentService.GetComments));
        }
    }
}