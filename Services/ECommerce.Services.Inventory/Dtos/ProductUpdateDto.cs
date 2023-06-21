namespace ECommerce.Services.Inventory.Dtos
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int NumberOfProducts { get; set; }
        public int CatalogId { get; set; }
    }
}
