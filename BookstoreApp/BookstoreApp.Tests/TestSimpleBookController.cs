using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookstoreApp.Controllers;
using BookstoreApp.Models;

namespace BookstoreApp.Tests
{
    [TestClass]
    public class TestSimpleBookController
    {
        [TestMethod]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            var testBooks = GetTestBooks();
            var controller = new SimpleBookController(testBooks);

            var result = controller.GetAllBooks() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count);
        }

        [TestMethod]
        public async Task GetAllBooksAsync_ShouldReturnAllBooks()
        {
            var testBooks = GetTestBooks();
            var controller = new SimpleBookController(testBooks);

            var result = await controller.GetAllBooksAsync() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count);
        }

        [TestMethod]
        public void GetBook_ShouldReturnCorrectBook()
        {
            var testBooks = GetTestBooks();
            var controller = new SimpleBookController(testBooks);

            var result = controller.GetBook(4) as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[3].Name, result.Content.Name);
        }

        [TestMethod]
        public async Task GetBookAsync_ShouldReturnCorrectBook()
        {
            var testBooks = GetTestBooks();
            var controller = new SimpleBookController(testBooks);

            var result = await controller.GetBookAsync(4) as OkNegotiatedContentResult<Book>;
            Assert.IsNotNull(result);
            Assert.AreEqual(testBooks[3].Name, result.Content.Name);
        }

        [TestMethod]
        public void GetBook_ShouldNotFindBook()
        {
            var controller = new SimpleBookController(GetTestBooks());

            var result = controller.GetBook(999);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        private List<Book> GetTestBooks()
        {
            var testBooks = new List<Book>();
            testBooks.Add(new Book { Id = 1, Name = "Alicja w krainie czarów", Price = 1 });
            testBooks.Add(new Book { Id = 2, Name = "Harry Potter", Price = 3.75M });
            testBooks.Add(new Book { Id = 3, Name = "Zbrodnia i kara", Price = 16.99M });
            testBooks.Add(new Book { Id = 4, Name = "Metro 2033", Price = 11.00M });

            return testBooks;
        }
    }
}
