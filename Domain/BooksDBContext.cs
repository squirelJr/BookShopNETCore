using Abstractions.DTO;
using Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;

namespace Domain
{

    public class BooksDBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
       public BooksDBContext(DbContextOptions<BooksDBContext> options) : base(options) { }

    }


}