namespace DL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string UserLogin { get; set; }

        [ForeignKey("Books")]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BooksId { get; set; }

        [StringLength(1000)]
        public string Text { get; set; }

        public Books Books { get; set; }
    }
}
