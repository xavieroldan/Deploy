using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginMVC.Models;
using LoginMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginMVCContext _context;

        public LoginController(LoginMVCContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckUser(string User, string Password)
        {
            var users = from u in _context.User
                        select u;

            if (!String.IsNullOrEmpty(User)||!String.IsNullOrEmpty(Password))
            {
                users = users.Where(s => s.Name.Contains(User));
                foreach (var item in users)
                {
                    if (item.Pass == Password)
                    {
                        //Select here the Home page after Login
                        return View("LogOk");
                    }
                }
            }
                return View("Error");
        }

        public string Test()
        {
            return "Test done OK";
        }

        public IActionResult Test2(string name, int numTimes =1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}