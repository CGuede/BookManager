using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookManager.Repositories
{
    public class GenericRepository<TEntity> : IDisposable where TEntity : class
    {
        public  ApplicationDbContext context;
        protected DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            this.context = new ApplicationDbContext();
            dbSet = context.Set<TEntity>();
        }

        public void Delete(int entityID)
        {
            TEntity entity = dbSet.Find(entityID);
            dbSet.Remove(entity);
        }

        public TEntity GetByID(int entityId)
        {
            return dbSet.Find(entityId);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
