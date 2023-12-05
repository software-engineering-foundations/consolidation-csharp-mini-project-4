using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Database;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("library");
    }
}
