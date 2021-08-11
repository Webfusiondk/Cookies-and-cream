using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookies_and_cream.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BakeAndShakeController : Controller
    {
        CookieOptions cookie = new CookieOptions();
        [HttpGet]
        [Route("OrderShake")]
        public string OrderShake(string shake)
        {
            cookie.Expires = DateTimeOffset.Now.AddMinutes(5);
            Response.Cookies.Append("Shake", shake, cookie);
            return "Shake is ordered";
        }

        [HttpGet]
        [Route("GetShake")]
        public string GetShake()
        {
            return "Here is your shake with: " + Request.Cookies["Shake"];
        }
    }
}
