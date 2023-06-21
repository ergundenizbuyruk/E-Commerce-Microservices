using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Services.Inventory.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int NumberOfProducts { get; set; }
        public int CatalogId { get; set; }
    }
}
