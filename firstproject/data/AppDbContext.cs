using firstproject.data.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<book_author>()
                .HasOne(b => b.book)
                .WithMany(ba => ba.book_authors)
                .HasForeignKey(bi => bi.bookId);

            modelBuilder.Entity<book_author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.book_authors)
                .HasForeignKey(bi => bi.authorId);

        }
        public DbSet<book> Books { get; set; }
        public DbSet<author> Authors { get; set; }
        public DbSet<book_author> book_Authors { get; set; }
        public DbSet<publisher> Publishers { get; set; }
    }
}
