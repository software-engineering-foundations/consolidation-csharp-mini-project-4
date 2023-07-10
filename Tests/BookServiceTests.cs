using consolidation_csharp_mini_project_3.Database;
using consolidation_csharp_mini_project_3.Models;
using consolidation_csharp_mini_project_3.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class BookServiceTests
    {
        private BookService bookService;

        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<DBContext>();
            builder.UseInMemoryDatabase("library");
            var db = new DBContext(builder.Options);
            db.Database.EnsureCreated();
            DBPopulator.PopulateDatabase();
            bookService = new BookService(db);
        }

        [TearDown]
        public void TearDown()
        {
            new DBContext().Database.EnsureDeleted();
        }

        [TestCase("", 50)]
        [TestCase("The Smug Mammals", 1)]
        [TestCase("Isaiah", 2)]
        public void TestGetBooks(string query, int expectedNumber)
        {
            Assert.That(bookService.GetBooks(query).Count() == expectedNumber);
        }

        [TestCase(1, "The Witty Rascals")]
        [TestCase(2, "The Skilled Dogs")]
        [TestCase(50, "The Hungry Swans")]
        public void TestGetBookById(int id, string expectedTitle)
        {
            Assert.That(bookService.GetBookById(id).Title == expectedTitle);
        }

        [Test]
        public void TestCreateBook()
        {
            var newBook = new Book
            {
                Title = "The Test Book",
                Author = "The Test Author",
                Description = "A test book created for the purpose of unit testing."
            };

            bookService.CreateBook(newBook);
            var createdBook = bookService.GetBookById(51);
            Assert.That(newBook.Title == createdBook.Title);
        }

        [Test]
        public void TestUpdateBook()
        {
            var bookUpdate = new Book
            {
                Title = "The Witty Rascalz",
                Author = "Hideo Saito"
            };

            bookService.UpdateBook(1, bookUpdate);
            var updatedBook = bookService.GetBookById(1);
            Assert.Multiple(() =>
            {
                Assert.That(updatedBook.Title == bookUpdate.Title);
                Assert.That(updatedBook.Author == bookUpdate.Author);
                Assert.That(updatedBook.Description.Length > 0);
            });
        }

        [Test]
        public void TestDeleteBook()
        {
            bookService.DeleteBook(1);
            Assert.That(bookService.GetBooks().All(b => b.Id != 1));
        }
    }
}