using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BModel
{
    public class BGenre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}
