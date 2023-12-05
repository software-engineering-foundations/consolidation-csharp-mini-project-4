using Library.Database;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories;

public interface IBookRepo
{
    List<Book> GetBooks(string? search = "");
    Book GetBookById(int id);
    Book CreateBook(Book bookModel);
    void UpdateBook(int id, Book bookModel);
    void DeleteBook(int id);
}

public class BookRepo : IBookRepo
{
    private readonly LibraryContext _context;

    public BookRepo(LibraryContext context)
    {
        _context = context;
    }

    public List<Book> GetBooks(string? search = "")
    {
        var books = _context.Books.AsQueryable();
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
        return _context.Books
            .Include(book => book.Loans)
            .ThenInclude(loan => loan.Customer)
            .Single(book => book.Id == id);
    }

    public Book CreateBook(Book bookModel)
    {
        var book = _context.Books.Add(bookModel);
        _context.SaveChanges();
        return book.Entity;
    }

    public void UpdateBook(int id, Book bookModel)
    {
        var book = _context.Books.Single(b => b.Id == id);
        book.Title = bookModel.Title;
        book.Author = bookModel.Author;
        book.Description = bookModel.Description;
        _context.SaveChanges();
    }

    public void DeleteBook(int id)
    {
        var book = _context.Books.Single(b => b.Id == id);
        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}
