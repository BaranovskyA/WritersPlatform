using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CommentModel
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        [Required]
        public int BooksId { get; set; }
        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
    }
}