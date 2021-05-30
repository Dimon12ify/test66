using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_66bit.Contexts;
using Test_66bit.Models;

namespace Test_66bit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Footballer(Footballer footballer)
        {
            return View(footballer);
        }
        
        [HttpGet] 
        public IActionResult Post() {
            return View(); 
        }  

        [HttpPost]
        public IActionResult Post(Footballer input)
        {
            if (ModelState.IsValid)
            {  
                Console.WriteLine(input.Name + " " + input.Surname);
                return RedirectToAction("Footballer", input);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}