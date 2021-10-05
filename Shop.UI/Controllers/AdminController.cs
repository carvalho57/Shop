
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.ProductsAdmin;
using Shop.Database;

namespace Shop.UI.Controllers 
{
    //https://restfulapi.net/resource-naming/
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        [HttpGet("products")]
        public IActionResult GetProducts([FromServices] GetProducts getProducts){
            return Ok(getProducts.Do());   
        }
            

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(
            int id,
            [FromServices] GetProduct getProduct) =>
            Ok(getProduct.Do(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(
            [FromBody] CreateProduct.Request request,
            [FromServices] CreateProduct createProduct) =>
            Ok((await createProduct.Do(request)));

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(
            int id,
            [FromServices] DeleteProduct deleteProduct) =>
            Ok((await deleteProduct.Do(id)));

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct(
            [FromBody] UpdateProduct.Request request,
            [FromServices] UpdateProduct updateProduct) =>
            Ok((await updateProduct.Do(request)));
    }
}