using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        Accounts accObj = new Accounts();
        [HttpGet]
        [Route("importantacc")]
        public IActionResult GetAccounts()
        {
            return Ok( accObj.GetALlAccounts());
        }
    }
}
