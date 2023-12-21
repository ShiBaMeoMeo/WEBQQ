using Microsoft.AspNetCore.Mvc;
using pinkshop.Models;
using System.Diagnostics;
using pinkshop.Data;

namespace pinkshop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _dbContext;


        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            this._dbContext = context;
        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.ToList();
            return View(products);
        }
        //T?o m?t action list c?a HomeController cho Default.cshtml c?a folder Compoents/Category/Default.cshtml
        public IActionResult List(int id)
        {
            var products = _dbContext.Products.Where(c=>c.CategoryId==id).ToList();
            return View(products);
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
