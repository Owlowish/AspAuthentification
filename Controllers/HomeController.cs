using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Authentification.Models;
using Microsoft.AspNetCore.Authorization;




namespace Authentification.Controllers
{
    public class HomeController : Controller
    {
       
       private readonly UserContext _context;


        public HomeController(UserContext context)
        {
            _context = context;
        }
       
      
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
            
            // ##############  TEST ###################################

           
           
           
           // recherche dans la base de donnée l'élément correspondant aux critères
            try
            {
                var userdb = (from m in _context.User
                            where (m.UserNumber == user.UserNumber )
                            select m).Single();
                            
             //OUTPUT
            Console.WriteLine("\n"+"\n"+"************  DEBUG ****************"+"\n"+"\n");
            
            Console.WriteLine ("Username INPUT : " + user.UserNumber);
            Console.WriteLine ("Password INPUT : " + user.Password);
            Console.WriteLine ("DataBase -- UserID : " + userdb.UserNumber + "  Password : " +  userdb.Password + "  Name : " + userdb.FirstName );
            Console.WriteLine("\n"+"\n"+"************************************"+"\n"+"\n");

            if (userdb.Password == user.Password)
            return RedirectToAction("Index","User");
                
            }
            catch (System.Exception)
            {      
                 return View(user);
            }
            
           

              // ##############  TEST ###################################

              


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
