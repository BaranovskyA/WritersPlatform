using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BModel
{
    public class BComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public int BooksId { get; set; }
        public string Text { get; set; }
    }
}
