using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data;
using ProjectTest.Dto;
using ProjectTest.Model;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;
        private readonly ProjectTestDbContext _projectTestDb;

       
        public ProductController(ILogger<ProductController> logger, ProjectTestDbContext projectDb)
        {
            _logger = logger;
            _projectTestDb = projectDb;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return _projectTestDb.Product.ToList();
        }

        [HttpGet("{id}")]
        public Product? GetProduct(Guid id)
        {
            var product = FindProduct(id);

            return product;
        }

        [HttpPost(Name = "CreateProduct")]
        public Product AddProduct(AddProduct addproduct)
        {
           
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = addproduct.ProductName,
                UnitPrice = addproduct.UnitPrice,
                QuantityInStock = addproduct.QuantityInStock
            };

            _projectTestDb.Product.Add(product);
            _projectTestDb.SaveChanges();

            return product;
        }
           

        [HttpDelete("id")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = FindProduct(id);

            _projectTestDb.Product.Remove(product);

            _projectTestDb.SaveChanges();

            return Ok();

        }

        [HttpPut("id")]

        public Product? UpdateProduct(Guid id, UpdateProduct updateProduct)
        {
            var product = FindProduct(id);

            product.ProductName = updateProduct.ProductName;
            product.UnitPrice = updateProduct.UnitPrice;
            product.QuantityInStock = updateProduct.QuantityInStock;

            _projectTestDb.SaveChanges();

            return product;
        }


        private Product? FindProduct(Guid id)
        {
            var product = _projectTestDb.Product.FirstOrDefault(p => p.Id == id);
            return product;
        }


      


    }
}
