using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.IdentityServer.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string OpenAddress { get; set; }
        public string NameOfThePersontoReceiveDelivery { get; set; }
        public string SurnameOfThePersontoReceiveDelivery { get; set; }
        public string PhoneNumberOfThePersontoReceiveDelivery { get; set; }
        public AddressType Type { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
