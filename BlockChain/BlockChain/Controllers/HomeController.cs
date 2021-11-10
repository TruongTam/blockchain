using BlockChain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlockChain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BlockChain.Models.helpermodel;

namespace BlockChain.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlockChainContext context;
        public HomeController(BlockChainContext context1)
        {
            context = context1;
        }

        public async Task<IActionResult> Index()
        {

            return View("index", await context.PubBook.ToListAsync());
        }
        [Route("login")]
        public IActionResult Login()
        {
            return View("u");
        }
        [HttpPost]
        public IActionResult Loginverifile(string username, string password)
        {
            //var idr = context.Cus.Where(x => x.Username == username).Select(x => new Login{ Id=x.Id });
            var user = context.Cus.Where(x => x.Username == username && x.Password == password).ToList();
            if (user.Count()==1)
            {
                HttpContext.Session.SetString("username", username);
               // HttpContext.Session.SetInt32("ID", id);
                return View("oke",user);
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
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
