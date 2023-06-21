namespace ECommerce.Services.Order.Models
{
    public class ProductOrder
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }
    }
}
