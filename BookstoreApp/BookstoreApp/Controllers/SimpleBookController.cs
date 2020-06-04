using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BookstoreApp.Models;


namespace BookstoreApp.Controllers
{
    public class SimpleBookController : ApiController
    {
        List<Book> books = new List<Book>();

        public SimpleBookController() { }

        public SimpleBookController(List<Book> books)
        {
            this.books = books;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await Task.FromResult(GetAllBooks());
        }

        public IHttpActionResult GetBook(int id)
        {
            var book = books.FirstOrDefault((p) => p.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        public async Task<IHttpActionResult> GetBookAsync(int id)
        {
            return await Task.FromResult(GetBook(id));
        }
    }
}
