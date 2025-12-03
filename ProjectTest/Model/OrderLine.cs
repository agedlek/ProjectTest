namespace ProjectTest.Model
{
    public class OrderLine
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
