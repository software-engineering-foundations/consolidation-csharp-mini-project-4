using consolidation_csharp_mini_project_3.Database;
using consolidation_csharp_mini_project_3.Models;
using consolidation_csharp_mini_project_3.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace consolidation_csharp_mini_project_3.Controllers
{

    [Route("books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService; 
        }
    
        [HttpGet]
        public ActionResult<List<Book>> GetBooks([FromQuery] string? search)
        {
            return Ok(bookService.GetBooks(search));
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            return Ok(bookService.GetBookById(id));
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] Book model)
        {
            var book = bookService.CreateBook(model);
            return CreatedAtAction("GetBookById", new { id = book.Id}, model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book model)
        {
            bookService.UpdateBook(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            bookService.DeleteBook(id);
            return Ok();
        }
    }
}