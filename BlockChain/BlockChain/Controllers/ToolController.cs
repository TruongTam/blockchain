using BlockChain.Models;
using BlockChain.Models.helpermodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Controllers
{
    public class ToolController : Controller
    {
        private readonly BlockChainContext chainContext;
        public ToolController(BlockChainContext context)
        {
            chainContext = context;
        }
        [Route("Tool/Index")]
        public async  Task<IActionResult> Index()
        {

            return View(await chainContext.Cus.ToListAsync());
        }
        [HttpGet]
        public IActionResult Trade(int? id)
        {
            var name = HttpContext.Session.GetString("username");
            ViewBag.check = name;
            var cus1 = chainContext.Cus.Where(x => x.Username==name).ToList();
            var cus2 = chainContext.Cus.Where(x => x.Id == id).ToList();
            return View(new Trade {cus1= cus1,cus2= cus2 });
        }
        public IActionResult Insertresult( int? id, string name, int val, string hash)
        {

        }

    }
}
