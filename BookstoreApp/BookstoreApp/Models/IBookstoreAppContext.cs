using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApp.Models
{
    public interface IBookstoreAppContext : IDisposable
    {
        DbSet<Book> Books { get; }
        int SaveChanges();
        void MarkAsModified(Book item);
    }
}
