using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreApp.Models;

namespace BookstoreApp.Tests
{
    class TestBookDbSet : TestDbSet<Book>
    {
        public override Book Find(params object[] keyValues)
        {
            return this.SingleOrDefault(book => book.Id == (int)keyValues.Single());
        }
    }
}
