using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies_and_cream
{
    public class Product
    {
        public Product(string name, int price, int ammount)
        {
            Name = name;
            Price = price;
            Ammount = ammount;
        }

        public string Name { get; set; }
        public int Ammount { get; set; }
        public int Price { get; set; }
    }
}
