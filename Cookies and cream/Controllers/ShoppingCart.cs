using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies_and_cream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCart : Controller
    {
        List<Product> cart;
        static List<Product> products = new List<Product>()
        {
            new Product("FaxeKondi", 10),
            new Product("CocaCola", 10),
            new Product("Fanta", 10),
            new Product("RedBull", 15),
            new Product("Dounut", 10)

        };
        [HttpGet]
        public string AddToCart(string name, int price)
        {
            cart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            if (cart == null)
            {
                cart = new List<Product>();
            }
            Product temp = MatchItem(name, price);
            if (temp != null)
            {
                cart.Add(temp);
                HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
            }

            return "Item not found";
        }

        public Product MatchItem(string name, int price)
        {
            foreach (var item in products)
            {
                if (name == item.Name)
                {
                    if (price == item.Price)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        [HttpGet]
        [Route("Products")]
        public List<Product> Products()
        {
            return products;
        }

    }
}
