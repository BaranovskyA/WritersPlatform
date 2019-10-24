using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.BModel;
using DataLayer.Repository;
using DataLayer.Entities;
using BusinessLayer.Utils;
using BusinessLayer.BInterfaces;
using DataLayer.Interfaces;
using DL.Entities;

namespace BusinessLayer.Services
{
    public class CommentService : ICommentService
    {
        IUnitOfWork Database { get; set; }

        public CommentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(BComment comment)
        {
            Comments commentt = new Comments() { BooksId = comment.BooksId, Text = comment.Text };
            Database.Comments.Create(commentt);               
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public BComment GetComment(int id)
        {
            if (id != 0)
            {
                return AutoMapper<Comments, BComment>.Map(Database.Comments.Get,(int)id);
            }
            return new BComment();
        }

        public IEnumerable<BComment> GetComments()
        {

            return AutoMapper<IEnumerable<Comments>, List<BComment>>.Map(Database.Comments.GetAll);
        }

        public void DeleteComment(int id)
        {
            Database.Comments.Delete(id);
            Database.Save();
        }

        public BComment GetForText(string text)
        {
            BComment author = AutoMapper<Comments, BComment>.Map(Database.Comments.Find(i => i.Text == text).FirstOrDefault());
            if (author != null)
            {
                return author;
            }
            return new BComment();
        }

        public BUsers GetUser(int id)
        {
            BUsers user = AutoMapper<Users, BUsers>.Map(Database.Users.Find(i => i.Id == id).FirstOrDefault());
            return user;
        }
    }
}

