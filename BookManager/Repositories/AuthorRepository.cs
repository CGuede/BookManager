using BookManager.Models;
using BookManager.Repositories.Interfaces;

namespace BookManager.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository() : base()
        {

        }
    }
}