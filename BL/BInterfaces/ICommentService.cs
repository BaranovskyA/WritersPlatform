using BusinessLayer.BModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BInterfaces
{
    public interface ICommentService
    {
        void Create(BComment comment);
        BComment GetComment(int id);
        IEnumerable<BComment> GetComments();
        void DeleteComment(int id);
        BComment GetForText(string text);
        BUsers GetUser(int id);
        void Dispose();
    }
}
