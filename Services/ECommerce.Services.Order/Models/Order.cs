namespace ECommerce.Services.Order.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }//Düzenle
        public double CargoAmount { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }

        public double getTotalPrice()
        {
            double price = 0;
            if (ProductOrders != null)
            {
                ProductOrders.ForEach(p =>
                {
                    price += p.Price;
                });
            }
            return price + CargoAmount;
        }
    }
}
