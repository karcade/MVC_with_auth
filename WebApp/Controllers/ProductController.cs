using Microsoft.AspNetCore.Mvc;
using WebApp.BussinessLogic.Services.Interfaces;
using WebApp.Model.DatabaseModels;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var Product = _productService.Get(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }
            _productService.Update(Product);
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(Product Product)
        {
            _productService.Create(Product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
