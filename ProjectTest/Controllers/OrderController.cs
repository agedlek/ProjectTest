using Microsoft.AspNetCore.Mvc;
using ProjectTest.Data;
using ProjectTest.Dto;
using ProjectTest.Model;
using System.Data;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:ControllerBase
    {

        private readonly ILogger<OrderController> _OrderLogger;
        private readonly ProjectTestDbContext _projectTestDb;
        

        public OrderController(ILogger<OrderController> orderLogger, ProjectTestDbContext projectDb)
        {
            _OrderLogger = orderLogger;
            _projectTestDb = projectDb;
            
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<Order> GetAllOrders()
        {
            return _projectTestDb.Order.ToList();

        }

        [HttpGet("{id}")]
        public Order? GetOrder(Guid id)
        {
            var order = FindOrder(id);
            return order;
        }

        [HttpPut("{id}")]

        public Order UpdateOrder(Guid id, UpdateOrder updateOrder)
        {
            var order = FindOrder(id);
            order.OrderName = updateOrder.Name;
            order.OrderSurname = updateOrder.Surname;
            order.OrderAdress = updateOrder.Adress;

            _projectTestDb.SaveChanges();
            return order;
        }

        [HttpPost(Name = "CreateOrder")]
        public Order CreateOrder(AddOrder addOrder)
        {

            var newOrder = new Order {
                Id = Guid.NewGuid(),
                OrderName = addOrder.OrderName,
                OrderSurname = addOrder.OrderSurname,
                OrderAdress = addOrder.OrderAdress,
                OrderLines = addOrder.OrderLines
            };

            _projectTestDb.Order.Add(newOrder);

            _projectTestDb.SaveChanges();
            
            return newOrder; 
        }

        [HttpDelete("id")]
        public IActionResult DeleteOrder(Guid id)
        {
            var order = FindOrder(id);

            _projectTestDb.Order.Remove(order);

            return Ok();
        }

        private Order? FindOrder(Guid id)
        {
            var order = _projectTestDb.Order.FirstOrDefault(o=> o.Id == id);
            return order;
        }

    }

}
