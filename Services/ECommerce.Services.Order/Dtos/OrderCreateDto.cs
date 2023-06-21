namespace ECommerce.Services.Order.Dtos
{
    public class OrderCreateDto
    {
        public int UserId { get; set; }
        public double CargoAmount { get; set; }
        public string Address { get; set; }
        public List<ProductOrderDto> ProductOrders { get; set; }
    }
}
