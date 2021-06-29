using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab3.Models
{
    public partial class DataBook : DbContext
    {
        public DataBook()
            : base("name=DataBook")
        {
        }

        public virtual DbSet<SACH> SACHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SACH>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SACH>()
                .Property(e => e.AnhBia)
                .IsUnicode(false);
        }
    }
}
