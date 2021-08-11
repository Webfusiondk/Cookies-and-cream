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
            new Product("FaxeKondi", 10, 5),
            new Product("CocaCola", 10, 5),
            new Product("Fanta", 10, 5),
            new Product("RedBull", 15, 5),
            new Product("Dounut", 10, 3)

        };

        [HttpGet]
        [Route("Additem")]
        public string AddToCart(string name, int price)
        {
            //Checks if the cart all rdy exits
            cart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            if (cart == null)
            {
                cart = new List<Product>();
            }
            //checks if the product we are looking for exits
            //then we add the product to the cart
            Product temp = MatchItem(name, price);
            if (temp != null)
            {
                temp.Ammount = 1;
                //checks if we are trying to add a duplicated item.
                //So we can incress the ammount insted of adding the same object.
                CheckForDuplicates(cart, temp);
                HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
                return "Item added to the shopping cart";
            }

            return "Item not found";
        }

        private void CheckForDuplicates(List<Product> cart, Product product)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Name == product.Name)
                {
                    cart[i].Ammount++;
                    //Break the loop after we add the duplicate
                    break;
                }
                //Check if we are at the end of the loop
                else if (i == cart.Count - 1)
                {
                    //If no duplicates found add the item
                    cart.Add(product);
                    break;
                }
            }
            //Checks if the cart is empty
            //then we will add the first item
            if (cart.Count == 0)
            {
                cart.Add(product);
            }
        }

        private Product MatchItem(string name, int price)
        {
            foreach (var item in products)
            {
                if (name == item.Name.ToLower())
                {
                    if (price == item.Price)
                    {
                        if (item.Ammount > 0)
                        {
                            item.Ammount -= 1;
                            return new Product(name, price, item.Ammount);

                        }
                        else if (item.Ammount == 0)
                        {
                            products.Remove(item);
                            return null;
                        }
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

        [HttpGet]
        [Route("ShowCart")]
        public List<Product> ShowCart()
        {
            cart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            return cart;
        }
    }
}
