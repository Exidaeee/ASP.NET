using Shop.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> :IDisposable
        where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string ? includeProperties = null);
        T Get(int id);
        //T GetId(ApplicationDbContext db, string name);
        void Add(T item);       
        void Delete(T item);

    }
}
