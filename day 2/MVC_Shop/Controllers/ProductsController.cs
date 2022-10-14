using Microsoft.AspNetCore.Mvc;
using MVC_Shop.Models;
namespace MVC_Shop.Controllers
{
    public class ProductsController : Controller
    {

        ProductsModel pObj = new ProductsModel();
      public IActionResult ShowProducts()
      {
            return View(pObj.GetAllProducts());
      }
    }
}
