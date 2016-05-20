using BookManager.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BookManager.Models;

namespace BookManager.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository() : base()
        {           
            
        }

        public IEnumerable<Author> GetAuthors()
        {
            return context.Authors.ToList();
        }

        public IEnumerable<Book> GetOrderedAndFiltered(string sortedProperty, string searchString, bool sortDesc)
        {
            List<Book> books;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                books = dbSet.Where(s => (s.Author.Name != null && s.Author.Name.ToLower().Contains(searchString))
                                || s.Title.ToLower().Contains(searchString)
                                || s.Genre.ToLower().Contains(searchString)
                                || s.ShortDesc.ToLower().Contains(searchString)).ToList();
            }
            else
                books = dbSet.ToList();

            if (sortDesc)
                return books.OrderByDescending(x => x.GetType().GetProperty(sortedProperty).GetValue(x, null));
            else
                return books.OrderBy(x => x.GetType().GetProperty(sortedProperty).GetValue(x, null));  
        }
    }
}
