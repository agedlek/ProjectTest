using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data;
using ProjectTest.Model;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ILogger<ProductController> _logger;
        private readonly ProjectTestDbContext _projectTestDb;

        private List<Product> products;
       
        public ProductController(ILogger<ProductController> logger, ProjectTestDbContext projectDb)
        {
            _logger = logger;
            _projectTestDb = projectDb;

            products = new List<Product>()
            {
                new Product{
                    Id = Guid.Parse("2a2f376b-5648-497e-8b23-aadcdee15a29"),
                    ProductName = "Product1",
                    QuantityInStock = 1,
                    UnitPrice = 2
                },
                new Product{
                    Id = Guid.Parse("8b5527dd-eaec-48db-b4a5-ff7aa827a325"),
                    ProductName = "Product2",
                    QuantityInStock = 3,
                    UnitPrice = 2
                }
            };

            products.Add(new Product
            {
                Id = Guid.Parse("8d699719-ed78-4023-adeb-fe4333255961"),
                ProductName = "Product3",
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
            var product = FindProduct(id);

            return product;
        }

        [HttpPost(Name = "CreateProduct")]
        public Product AddProduct(string productName, double unitPrice, int quantityInStock)
        {
           
            var product = new Product
            {
                Id = Guid.NewGuid(),
                ProductName = productName,
                UnitPrice = unitPrice,
                QuantityInStock = quantityInStock
            };

            _projectTestDb.Product.Add(product);
            _projectTestDb.SaveChanges();

            return product;
        }
           

        [HttpDelete("id")]
        public List<Product> DeleteProduct(Guid id)
        {
            var product = FindProduct(id);

            products.Remove(product);

            return products;
        }

        [HttpPut("id")]

        public Product? UpdateProduct(Guid id, Product updateProduct)
        {
            var product = FindProduct(id);

            product.ProductName = updateProduct.ProductName;
            product.UnitPrice = updateProduct.UnitPrice;
            product.QuantityInStock = updateProduct.QuantityInStock;

            return product;
        }


        private Product? FindProduct(Guid id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }


      


    }
}
