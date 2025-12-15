using ProjectTest.Model;

namespace ProjectTest.Dto
{
    public class AddOrderLine
    {
        public Guid  ProductId { get; set; }
        public int Quantity { get; set; }
        
    }
}
