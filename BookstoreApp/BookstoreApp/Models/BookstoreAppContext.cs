using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookstoreApp.Models
{
    public class BookstoreAppContext : DbContext, IBookstoreAppContext
    {
    
        public BookstoreAppContext() : base("name=BookstoreAppContext")
        {
        }

        public DbSet<Book> Books { get; set; }

        public void MarkAsModified(Book item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
