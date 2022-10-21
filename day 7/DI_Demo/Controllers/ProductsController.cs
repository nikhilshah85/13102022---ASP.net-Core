using Microsoft.AspNetCore.Mvc;
using DI_Demo.Models;
namespace DI_Demo.Controllers
{
    public class ProductsController : Controller
    {

        //  Products pObj = new Products(); // this is a crime, we are craeteing the object, so we need to destroy the same


        Products _pObj;
        public ProductsController(Products _pObjREF)
        {
            _pObj = _pObjREF;
        }
        public IActionResult Index()
        {
            return View(_pObj.GetAllProducts());
        }
    }
}
