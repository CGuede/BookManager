using BookManager.Models;
using BookManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.Interfaces
{
    public interface IBookRepository: IRepository<Book>, IDisposable
    {       
        IEnumerable<Author> GetAuthors();
        IEnumerable<Book> GetOrderedAndFiltered(string sortedProperty, string searchString, bool sortDesc);
    }
}
