namespace ProjectTest.Model
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Guid ProductId { get; set; }

        public Order Order { get; set; }

        public Guid OrderId { get; set; }

    }
}
