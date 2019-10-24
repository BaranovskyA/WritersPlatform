namespace DL.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DataLayer.Entities;

    public partial class Model1 : DbContext
    {
        public Model1(string connection)
            : base(connection)
        {
        }

        public Model1()
            : base("DefaultConnection")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public DbSet<LogDetail> LogDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Genres)
                .HasForeignKey(e => e.Genres_Id);
        }
    }
}
