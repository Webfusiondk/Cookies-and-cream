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
    public class MilkController : Controller
    {
        CookieOptions options = new CookieOptions();
        [HttpGet]
        [Route("Cookies")]
        public string ReturnCookie()
        {
            return Request.Cookies["Cookie"];
        }

        [HttpGet]
        [Route("Crumble")]
        public string CookieCruble()
        {
            options.Expires = DateTimeOffset.Now.AddDays(-1);
            Response.Cookies.Delete("Cookie", options);
            Response.Cookies.Delete("Shake", options);
            return "Your cookie has crumbled";
        }
    }
}
