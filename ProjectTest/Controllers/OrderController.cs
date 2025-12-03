using Microsoft.AspNetCore.Mvc;
using ProjectTest.Model;
using System.Data;

namespace ProjectTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController:ControllerBase
    {

        private readonly ILogger<OrderController> _OrderLogger;
        public List<Order> orders { get; set; }

        public OrderController(ILogger<OrderController> orderLogger)
        {
            _OrderLogger = orderLogger;
            orders = new List<Order>()
            {
                new Order{
                    Id = Guid.Parse("217f0f20-ba0f-4715-a63b-29703b59557b"),
                    OrderName = "Julia",
                    OrderSurname = "Nowak",
                    OrderAdress = "Krakow",
                    OrderLines = new List<OrderLine>{
                         new OrderLine
                         {
                             Id= Guid.Parse("102948da-cd2f-4450-8916-1810cdbc301c"),
                             ProductId = Guid.Parse("2a2f376b-5648-497e-8b23-aadcdee15a29"),
                             Price = 23,
                             Quantity = 1
                         }
                    }
                },

                new Order{
                    Id = Guid.Parse("a8ebc286-dcf1-420a-9efd-5f61d8272d90"),
                    OrderName = "Adam",
                    OrderSurname = "Kowalski",
                    OrderAdress = "Wieliczka",
                    OrderLines = new List<OrderLine>{
                         new OrderLine
                         {
                             Id= Guid.Parse("102948da-cd2f-4450-8916-1810cdbc301c"),
                             ProductId = Guid.Parse("8b5527dd-eaec-48db-b4a5-ff7aa827a325"),
                             Price = 30,
                             Quantity = 2
                         }
                    }
                }
            };
        }

        [HttpGet(Name = "GetOrders")]
        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        [HttpGet("{id}")]
        public Order? GetOrder(Guid id)
        {
            var order = FindOrder(id);
            return order;
        }

        [HttpPut("{id}")]

        public Order UpdateOrder(Guid id, string updateName, string updateSurname, string updateAdress)
        {
            var order =FindOrder(id);
            order.OrderName = updateName;
            order.OrderSurname = updateSurname;
            order.OrderAdress = updateAdress;
            return order;
        }

        [HttpPost(Name = "CreateOrder")]
        public List<Order> CreateOrder(string orderName,string orderSurname, string orderAdress, List<OrderLine> orderLines)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                OrderName = orderName,
                OrderSurname =orderSurname,
                OrderAdress = orderAdress,
                OrderLines = orderLines
                    
            };

            orders.Add(newOrder);
            return orders;
        }

        [HttpDelete("id")]
        public List<Order> DeleteOrder(Guid id)
        {
            var order = FindOrder(id);

            orders.Remove(order);

            return orders;
        }

        private Order? FindOrder(Guid id)
        {
            var order = orders.FirstOrDefault(p => p.Id == id);
            return order;
        }

    }

}
