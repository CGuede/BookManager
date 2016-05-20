using System;
using System.Collections.Generic;

namespace BookManager.Repositories.Interfaces
{
    public interface IRepository<TModel> : IDisposable where TModel : class
    {
        IEnumerable<TModel> Get();
        TModel GetByID(int bookId);
        void Insert(TModel model);
        void Delete(int bookID);
        void Update(TModel model);
        void Save();      
    }
}
