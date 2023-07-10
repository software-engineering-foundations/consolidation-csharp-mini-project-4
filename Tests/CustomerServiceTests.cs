using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using consolidation_csharp_mini_project_3.Database;
using consolidation_csharp_mini_project_3.Models;
using consolidation_csharp_mini_project_3.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests
{
    public class CustomerServiceTests
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

        [TestCase("", 50)]
        [TestCase("Tabby", 1)]
        [TestCase("Mark", 2)]
        public void TestGetCustomers(string query, int expectedNumber)
        {
            Assert.That(new CustomerService().GetCustomers(query).Count() == expectedNumber);
        }

        [TestCase("PD-569797-8874", "Mark Davies")]
        [TestCase("MJ-600731-1698", "Mark Jackson")]
        [TestCase("TF-781410-1836", "Tabby Franklin")]
        public void TestGetCustomerByLibraryCardNumber(string libraryCardNumber, string expectedName)
        {
            Assert.That(new CustomerService().GetCustomerByLibraryCardNumber(libraryCardNumber).Name == expectedName);
        }

        [Test]
        public void TestCreateCustomer()
        {
            var newCustomer = new Customer
            {
                LibraryCardNumber = "PD-569797-8899",
                Name = "Testy Test",
                Email = "testy.test@gmail.com",
            };

            var customerService = new CustomerService();
            customerService.CreateCustomer(newCustomer);
            var createdCustomer = customerService.GetCustomerByLibraryCardNumber("PD-569797-8899");
            Assert.That(newCustomer.Name == createdCustomer.Name);
        }

        [Test]
        public void TestUpdateCustomer()
        {
            var customerUpdate = new Customer
            {
                Name = "Mark Davies Jr.",
                Email = "mark.davies.jnr@gmail.com",
            };

            var libraryCardNumber = "PD-569797-8874";
            var customerService = new CustomerService();
            customerService.UpdateCustomer(libraryCardNumber, customerUpdate);
            var updatedCustomer = customerService.GetCustomerByLibraryCardNumber(libraryCardNumber);
            Assert.Multiple(() =>
            {
                Assert.That(updatedCustomer.Name == customerUpdate.Name);
                Assert.That(updatedCustomer.Email == customerUpdate.Email);
            });
        }

        [Test]
        public void TestDeleteCustomer()
        {
            var libraryCardNumber = "PD-569797-8874";
            var customerService = new CustomerService();
            customerService.DeleteCustomer(libraryCardNumber);
            Assert.That(customerService.GetCustomers().All(b => b.LibraryCardNumber != libraryCardNumber));
        }
    }
}