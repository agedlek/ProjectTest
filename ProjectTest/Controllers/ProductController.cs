using Microsoft.AspNetCore.Mvc;
using ProjectTest.Model;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;

        private List<Product> products;
       
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            products = new List<Product>()
            {
                new Product{
                    Id = Guid.NewGuid(),
                    ProductName = "X",
                    QuantityInStock = 1,
                    UnitPrice = 2
                },
                new Product{
                    Id = Guid.NewGuid(),
                    ProductName = "yz",
                    QuantityInStock = 3,
                    UnitPrice = 2
                }
            };

            products.Add(new Product
            {
                Id = Guid.NewGuid(),
                ProductName = "yz",
                QuantityInStock = 3,
                UnitPrice = 2
            });

        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product? GetProduct(Guid id)
        {
           var product =  products.FirstOrDefault(p => p.Id == id);
            return products[0];
        }
    }
}
