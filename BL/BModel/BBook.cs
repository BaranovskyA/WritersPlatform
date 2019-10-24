using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BModel
{
    public class BBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public DateTime? DatePublishing { get; set; }
        public int? Rating { get; set; }
        public int RatingCount { get; set; }
        public int Respect { get; set; }
        public int? Genres_Id { get; set; }
        public virtual Genres Genres { get; set; }
    }
}
