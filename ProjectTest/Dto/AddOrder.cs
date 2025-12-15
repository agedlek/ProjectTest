using ProjectTest.Model;

namespace ProjectTest.Dto
{
    public class AddOrder
    {
        public string OrderName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderAdress { get; set; }
        public List<AddOrderLine> OrderLines { get; set; }
    }
}
