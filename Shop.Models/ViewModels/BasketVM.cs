using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.ViewModels
{
    public class BasketVM
    {
        public IEnumerable<Basket> BasketList { get; set; }
    }
}
