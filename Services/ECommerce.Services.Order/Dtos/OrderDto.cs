using ECommerce.Services.Order.Models;

namespace ECommerce.Services.Order.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductOrderDto> ProductOrders { get; set; }
        public double CargoAmount { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalPrice { get; set; }
    }
}
