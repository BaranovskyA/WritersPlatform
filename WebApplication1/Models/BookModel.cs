using DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100000000)]
        public string Text { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public DateTime? DatePublishing { get; set; }

        [Range(1,100)]
        public int? Rating { get; set; }

        public int RatingCount { get; set; }

        public int Respect { get; set; }

        public int? Genres_Id { get; set; }

        public virtual Genres Genres { get; set; }
    }
}