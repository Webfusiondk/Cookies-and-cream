using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies_and_cream
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }
    }
}
