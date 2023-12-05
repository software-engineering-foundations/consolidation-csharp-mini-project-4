using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookRepo _books;

    public BookController(IBookRepo books)
    {
        _books = books;
    }

    [HttpGet]
    public ActionResult GetBooks([FromQuery] string? search)
    {
        return Ok(_books.GetBooks(search));
    }

    [HttpGet("{id}")]
    public ActionResult GetBookById([FromRoute] int id)
    {
        try
        {
            return Ok(_books.GetBookById(id));
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult CreateBook([FromBody] Book bookModel)
    {
        var newBook = _books.CreateBook(bookModel);
        return CreatedAtAction("GetBookById", new { id = newBook.Id }, bookModel);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateBook([FromRoute] int id, [FromBody] Book bookModel)
    {
        try
        {
            _books.UpdateBook(id, bookModel);
            return Ok();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteBook([FromRoute] int id)
    {
        try
        {
            _books.DeleteBook(id);
            return Ok();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
}
