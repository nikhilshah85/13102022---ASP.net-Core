using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using productsAPI.Models;
using System.Security.Cryptography;

namespace productsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        Products pObj = new Products();

        [HttpGet]
        [Route("plist")]
        public IActionResult GetProducts()
        {
            return Ok(pObj.GetAllProducts());
        }

        [HttpGet]
        [Route("plist/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok(pObj.GetProductById(id));
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }


        [HttpPost]
        [Route("plist/add")]
        public IActionResult AddProduct(Products products)
        {
            return Created("", pObj.AddProduct(products));
        }

        [HttpDelete]
        [Route("plist/delete/{pid}")]
        public IActionResult DeleteProduct(int pid)
        {
            try
            {
                return Accepted(pObj.DeleteProduct(pid));
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }

        [HttpPut]
        [Route("plist/update")]
        public IActionResult UpdateProduct(Products changes)
        {
            try
            {
                return Accepted(pObj.updateProduct(changes));
            }
            catch (Exception es)
            {

                return NotFound(es.Message);
            }
        }
    }

}
