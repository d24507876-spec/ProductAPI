using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 50000 },
            new Product { Id = 2, Name = "Mobile", Price = 20000 }
        };

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return products;
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
