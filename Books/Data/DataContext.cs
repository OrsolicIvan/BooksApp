using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Author_Book>()
               .HasKey(a => new { a.AuthorId, a.BookId });

            modelBuilder.Entity<Ordering>()
               .HasKey(a => new { a.BookId, a.OrderId });

        }
        public DbSet<Author> AuthorInfo { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author_Book> Author_Books { get; set; }
        public DbSet<Book_Order> BookOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ordering> Orderings  { get; set; }


    }
}
