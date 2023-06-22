namespace ECommerce.Services.Basket.Dtos
{
    public class BasketDto
    {
        public Guid UserId { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}
