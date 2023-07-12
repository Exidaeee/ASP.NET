using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork: IDisposable
    {

        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IBasketRepository BasketRepository { get; }
        void Save();

    }
}
