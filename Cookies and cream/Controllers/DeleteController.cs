using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies_and_cream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteController : Controller
    {
        List<Product> cart;
        public string RemoveItem(string name)
        {
            cart = HttpContext.Session.GetObjectFromJson<List<Product>>("ShoppingCart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Name == name)
                {
                    if (cart[i].Ammount > 0)
                    {
                        cart[i].Ammount--;
                        if (cart[i].Ammount == 0)
                        {
                            cart.Remove(cart[i]);
                            HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
                            return "Item removed from Cart";
                        }
                        HttpContext.Session.SetObjectAsJson("ShoppingCart", cart);
                        return "Item removed from Cart";
                    }
                }
                //Check if we are at the end of the loop
                else if (i == cart.Count - 1)
                {
                    return "Item not found";
                }
            }
            return "Item not found";
        }
    }
}
