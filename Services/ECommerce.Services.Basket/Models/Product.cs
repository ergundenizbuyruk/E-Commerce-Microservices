using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Services.Basket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public Basket Basket { get; set; }

        [ForeignKey(nameof(Basket))]
        public Guid BasketId { get; set; }
    }
}
