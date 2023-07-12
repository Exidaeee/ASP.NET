using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IBasketRepository : IRepository<Basket>
    {
        void Update(Basket basket);
        void AddToBasket(Product product);
    }
}
