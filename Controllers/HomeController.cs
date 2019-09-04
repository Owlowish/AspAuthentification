using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authentification.Models;

namespace Authentification.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

     

         public IActionResult Login()
        {
            return View();
        }

        // HTTP POST
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Login(User user)
        {
            Console.WriteLine("\n"+"\n"+"************  DEBUG ****************"+"\n"+"\n");

            Console.WriteLine("\n"+"\n"+"************************************"+"\n"+"\n");


            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
