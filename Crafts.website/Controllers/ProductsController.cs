using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crafts.website.Models;
using Crafts.website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crafts.website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult<Product> Get(
            [FromQuery]string productId, 
            [FromQuery]int Rating)
        {
            ProductService.AddRating(productId, Rating);
                return Ok();
        }
    }
}
