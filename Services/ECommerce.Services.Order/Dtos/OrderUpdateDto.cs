using ECommerce.Services.Order.Models;

namespace ECommerce.Services.Order.Dtos
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
