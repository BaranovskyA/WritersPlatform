using DL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GenreModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string GenreName { get; set; }
        public virtual ICollection<Books> Books { get; set; }
    }
}