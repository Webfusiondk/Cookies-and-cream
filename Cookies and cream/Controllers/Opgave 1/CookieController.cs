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
    public class CookieController : Controller
    {
        CookieOptions options = new CookieOptions(); 
        [HttpGet]
        [Route("Cookie")]
        public string AddCookie(string cookie)
        {
            options.Expires = DateTimeOffset.Now.AddMinutes(5);
            Response.Cookies.Append("Cookie", cookie, options);
            return "Cookie addet";
        }
    }
}
