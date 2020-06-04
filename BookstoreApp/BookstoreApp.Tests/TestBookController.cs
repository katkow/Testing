using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using BookstoreApp.Models;
using BookstoreApp.Controllers;

namespace BookstoreApp.Tests
{
    
  [TestClass]
  public class TestBookController
        {

        [TestMethod]
        public void PostBook_ShouldReturnSameBook()
        {
            var controller = new BookController(new TestBookstoreAppContext());

            var item = GetDemoBook();

            var result =
                controller.PostBook(item) as CreatedAtRouteNegotiatedContentResult<Book>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.RouteName, "DefaultApi");
            Assert.AreEqual(result.RouteValues["id"], result.Content.Id);
            Assert.AreEqual(result.Content.Name, item.Name);
        }


        [TestMethod]
            public void PutBook_ShouldReturnStatusCode()
            {
                var controller = new BookController(new TestBookstoreAppContext());

                var item = GetDemoBook();

                var result = controller.PutBook(item.Id, item) as StatusCodeResult;
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
                Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
            }

            [TestMethod]
            public void PutBook_ShouldFail_WhenDifferentID()
            {
                var controller = new BookController(new TestBookstoreAppContext());

                var badresult = controller.PutBook(999, GetDemoBook());
                Assert.IsInstanceOfType(badresult, typeof(BadRequestResult));
            }

            [TestMethod]
            public void GetBook_ShouldReturnBookWithSameID()
            {
                var context = new TestBookstoreAppContext();
                context.Books.Add(GetDemoBook());

                var controller = new BookController(context);
                var result = controller.GetBook(3) as OkNegotiatedContentResult<Book>;

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Content.Id);
            }

            [TestMethod]
            public void GetBooks_ShouldReturnAllBooks()
            {
                var context = new TestBookstoreAppContext();
                context.Books.Add(new Book { Id = 1, Name = "Metro 2033", Price = 20 });
                context.Books.Add(new Book { Id = 2, Name = "Metro 2034", Price = 30 });
                context.Books.Add(new Book { Id = 3, Name = "Metro 2035", Price = 40 });

                var controller = new BookController(context);
                var result = controller.GetBooks() as TestBookDbSet;

                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.Local.Count);
            }

            [TestMethod]
            public void DeleteBook_ShouldReturnOK()
            {
                var context = new TestBookstoreAppContext();
                var item = GetDemoBook();
                context.Books.Add(item);

                var controller = new BookController(context);
                var result = controller.DeleteBook(3) as OkNegotiatedContentResult<Book>;

                Assert.IsNotNull(result);
                Assert.AreEqual(item.Id, result.Content.Id);
            }

            Book GetDemoBook()
            {
                return new Book() { Id = 3, Name = "Example name", Price = 5 };
            }
        }
    
}
