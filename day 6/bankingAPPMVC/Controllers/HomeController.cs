using bankingAPPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace bankingAPPMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Accounts()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccountsSecured()
        {
            AccountsAPI acc = new AccountsAPI();
            return View(acc.GetAccountsFromAPI());
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