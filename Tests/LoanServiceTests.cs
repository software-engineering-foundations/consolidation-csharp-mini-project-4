using consolidation_csharp_mini_project_3.Database;
using consolidation_csharp_mini_project_3.Models;
using consolidation_csharp_mini_project_3.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class LoanServiceTests
    {
        [SetUp]
        public void Setup()
        {
            var builder = new DbContextOptionsBuilder<DBContext>();
            builder.UseInMemoryDatabase("library");
            var db = new DBContext(builder.Options);
            db.Database.EnsureCreated();
            DBPopulator.PopulateDatabase();
        }

        [TearDown]
        public void TearDown()
        {
            new DBContext().Database.EnsureDeleted();
        }

        [Test]
        public void TestGetLoans()
        {
            Assert.That(new LoanService().GetLoans().Count() == DBPopulator.Loans.Count());
        }

        [TestCase("TE-435654-4935", 8)]
        [TestCase("TJ-151752-5225", 7)]
        public void TestGetLoansByCustomer(string libraryCardNumber, int expectedCount)
        {
            Assert.That(new LoanService().GetLoansByCustomer(libraryCardNumber).Count() == expectedCount);
        }

        [TestCase(10, 5)]
        [TestCase(1, 4)]
        public void TestGetLoansByBook(int bookId, int expectedCount)
        {
            Assert.That(new LoanService().GetLoansByBook(bookId).Count() == expectedCount);
        }

        [TestCase(1, 10)]
        [TestCase(2, 1)]
        [TestCase(3, 11)]
        public void TestGetLoanById(int id, int expectedBookId)
        {
            Assert.That(new LoanService().GetLoanById(id).BookId == expectedBookId);
        }

        [Test]
        public void TestCreateLoan()
        {
            var newLoan = new Loan
            {
                BookId = 10,
                CustomerLibraryCardNumber = "TE-435654-4935",
                DateLoaned = DateTime.Today - TimeSpan.FromDays(new Random().Next(21, 42)),
                DateDue = DateTime.Today + TimeSpan.FromDays(new Random().Next(-3, 18)),
                DateReturned = null
            };

            var loanService = new LoanService();
            loanService.CreateLoan(newLoan);
            var expectedId = DBPopulator.Loans.Count() + 1;
            var createdLoan = loanService.GetLoanById(expectedId);
            Assert.That(newLoan.CustomerLibraryCardNumber == createdLoan.CustomerLibraryCardNumber);
            Assert.That(newLoan.BookId == createdLoan.BookId);
        }

        [Test]
        public void TestUpdateLoan()
        {
            var loanUpdate = new Loan
            {
                DateReturned = DateTime.Today,
            };

            var id = 1;
            var loanService = new LoanService();
            loanService.UpdateLoan(id, loanUpdate);
            var updatedLoan = loanService.GetLoanById(id);
            Assert.Multiple(() =>
            {
                Assert.That(updatedLoan.DateReturned == loanUpdate.DateReturned);
            });
        }

        [Test]
        public void TestDeleteLoan()
        {
            var id = 1;
            var loanService = new LoanService();
            loanService.DeleteLoan(id);
            Assert.That(loanService.GetLoans().All(b => b.Id != id));
        }
    }
}