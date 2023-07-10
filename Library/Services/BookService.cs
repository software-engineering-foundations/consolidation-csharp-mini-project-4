using consolidation_csharp_mini_project_3.Database;
using consolidation_csharp_mini_project_3.Models;
using Microsoft.EntityFrameworkCore;

namespace consolidation_csharp_mini_project_3.Services
{
    public class BookService
    {
        private DBContext db;

        public BookService(DBContext context)
        {
            db = context;
        }

        public List<Book> GetBooks(string? search = "")
        {
            var books = db.Books.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                books = books.Where(book =>
                    book.Title.ToLower().Contains(search)
                    || book.Author.ToLower().Contains(search));
            }
            return books.ToList();
        }

        public Book GetBookById(int id)
        {
            return db.Books
                .Include(book => book.Loans)
                .ThenInclude(loan => loan.Customer)
                .Single(book => book.Id == id);
        }

        public Book CreateBook(Book model)
        {
            var book = db.Books.Add(model);
            db.SaveChanges();
            return book.Entity;
        }

        public void UpdateBook(int id, Book model)
        {
            var book = db.Books.Single(b => b.Id == id);
            book.Title = model.Title ?? book.Title;
            book.Author = model.Author ?? book.Author;
            book.Description = model.Description ?? book.Description;
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = db.Books.Single(b => b.Id == id);
            db.Books.Remove(book);
            db.SaveChanges();
        }
    }
}