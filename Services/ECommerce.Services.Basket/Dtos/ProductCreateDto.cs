namespace ECommerce.Services.Basket.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
