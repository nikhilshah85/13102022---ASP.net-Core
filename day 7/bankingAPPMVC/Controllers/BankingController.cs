using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace bankingAPPMVC.Controllers
{

    [Authorize]
    public class BankingController : Controller
    {

        [AllowAnonymous]
        public IActionResult BankingInfo()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult ContactBanking()
        {
            return View();
        }

        public IActionResult TransferFunds()
        {
            return View();
        }
        public IActionResult DownloadStatements()
        {
            return View();
        }
    }
}
