using consolidation_csharp_mini_project_3.Models;
using Microsoft.EntityFrameworkCore;

namespace consolidation_csharp_mini_project_3.Database
{
    public class DBContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public DBContext() {}
        public DBContext(DbContextOptions<DBContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("library");
        }
    }
}