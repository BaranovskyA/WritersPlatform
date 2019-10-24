using BusinessLayer.Utils;
using BusinessLayer;
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
using WebApplication1.Filters;
using DataLayer.Repository;
using DL.Entities;
using DataLayer.Interfaces;
using BusinessLayer.BInterfaces;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        IUserService userService;
        IBookService bookService;

        public UsersController(IUserService serv, IBookService serv2)
        {
            userService = serv;
            bookService = serv2;
        }

        public ActionResult Index()
        {
            List<UserModel> user = AutoMapper<IEnumerable<BUsers>, List<UserModel>>.Map(userService.GetUsers);
            UserModel currentUser = AutoMapper<BUsers, UserModel>.Map(userService.GetUserByLogin(Request.Cookies["authCookie"].Value));
            if(currentUser != null || currentUser.Id != 0)
            {
                ViewBag.UserIndex = currentUser;
            }
            else
            {
                ViewBag.UserIndex = 0;
            }
            return View();
        }

        public ActionResult CreateOrEdit(int? id = 0)
        {
            UserModel user = AutoMapper<BUsers, UserModel>.Map(userService.GetUser, (int)id);
            return View(user);
        }

        [Logger]
        [HttpPost]
        public ActionResult CreateOrEdit(UserModel model)
        {
            BUsers user = AutoMapper<UserModel, BUsers>.Map(model);
            var email = new System.Net.Mail.MailAddress(model.Email);
            if ((email.Address == model.Email) == true)
            {
                userService.CreateOrUpdate(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Authorization()
        {
            HttpCookie authCookie = new HttpCookie("authCookie");
            authCookie.Value = "";
            Response.Cookies.Add(authCookie);
            return View();
        }

        [HttpPost]
        public ActionResult Authorization(UserModel model)
        {
            UserModel user = AutoMapper<BUsers, UserModel>.Map(userService.GetUserByLogin, (string)model.Login);
            if ((model.Login == user.Login && model.Password == user.Password && user.IsDeleted == false) || (model.Email == user.Email && model.Password == user.Password && user.IsDeleted == false))
            {
                if(Request.Cookies["authCookie"] != null)
                {
                    Response.Cookies["authCookie"].Value = model.Login;
                }
                return RedirectToAction("Index", "Books");
            }
            return RedirectToAction("Index", "Books");
        }

        [Logger]
        public ActionResult Exit()
        {
            if (Request.Cookies["authCookie"] != null)
            {
                Response.Cookies["authCookie"].Value = "";
            }
            return RedirectToAction("Index", "Books");
        }

        [Logger]
        public ActionResult Delete(int id)
        {
            BUsers user = AutoMapper<BUsers, BUsers>.Map(userService.GetUser, (int)id);
            user.IsDeleted = true;
            userService.CreateOrUpdate(user);
            if (Request.Cookies["authCookie"] != null)
            {
                Response.Cookies["authCookie"].Value = "";
            }
            return RedirectToAction("Index", "Books");
        }

        public void Search(string request)
        {
            List<BookModel> books = AutoMapper<IEnumerable<BBook>, List<BookModel>>.Map(bookService.GetBooks);
            foreach (var item in books)
            {
                if(item.Title.Contains(request))
                {

                }
            }

        }
    }
}
