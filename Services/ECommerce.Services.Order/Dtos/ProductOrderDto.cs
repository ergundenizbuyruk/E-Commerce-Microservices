namespace ECommerce.Services.Order.Dtos
{
    public class ProductOrderDto
    {
        public int Count { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
