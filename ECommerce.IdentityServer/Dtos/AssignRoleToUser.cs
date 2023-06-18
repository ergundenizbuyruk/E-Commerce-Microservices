namespace ECommerce.IdentityServer.Dtos
{
    public class AssignRoleToUser
    {
        public Guid UserId { get; set; }

        public string RoleName { get; set; }
    }
}
