using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Data
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
