using System.ComponentModel.DataAnnotations;

namespace ECommerce.Services.Basket.Models
{
    public class Basket
    {
        public Guid UserId { get; set; }

        public List<Product> Products { get; set; }
    }
}
