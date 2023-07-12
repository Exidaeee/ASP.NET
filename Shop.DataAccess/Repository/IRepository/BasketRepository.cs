using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        private readonly ApplicationDbContext _db;
        public BasketRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void AddToBasket(Product product)
        {          
            if (product.Id != null || product.Id != 0)
            {
                var basketExists = _db.Baskets.Any();
                if (!basketExists)
                {
                    var basket = new Basket { Product = product };
                    _db.Baskets.Add(basket);
                    _db.SaveChanges();
                }
                else 
                { 
                    
                
                }
            }
        }

        public void Update(Basket obj)
        {
           _db.Update(obj);
        }
    }   
}
