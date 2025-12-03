namespace ProjectTest.Model
{
    public class Order
    {

        public Guid Id { get; set; }
        public string OrderName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderAdress { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
