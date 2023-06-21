using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Services.Inventory.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductPrice { get; set; }
        public int NumberOfProducts { get; set; }
        public Catalog Catalog { get; set; }

        [ForeignKey(nameof(Catalog))]
        public int CatalogId { get; set; }
    }
}
