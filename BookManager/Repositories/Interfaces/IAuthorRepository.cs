using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>, IDisposable
    {
    }
}
