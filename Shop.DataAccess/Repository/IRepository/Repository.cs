using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Shop.DataAccess.Repository.IRepository
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Products.Include(u => u.Category);                
        }
        public void Add(T item)
        {
           dbSet.Add(item);
        }

        public void Delete(T item)
        {          
            dbSet.Remove(item);           
        }        

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string ? includeProperties = null )
        {
            IQueryable<T> values = dbSet;
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var item in includeProperties.Split(new char[] {',' }))
                {
                    values = values.Include(item);
                }
            }
            return values.ToList();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public T GetId(ApplicationDbContext db, string name)
        //{
        //    var product = db.Products.FirstOrDefault(p => p.Id == );
        //    if (product != null)
        //    {
        //        return product.Id;
        //    }
        //    return 0;
        //}
    }
}

