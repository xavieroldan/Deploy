using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public string Index(string user = "user")
        //{
        //    return HtmlEncoder.Default.Encode($"Hello from the login {user}.");
        //}

        public string Test()
        {
            return "Test done OK";
        }
    }
}