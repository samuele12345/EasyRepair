using Microsoft.AspNetCore.Identity;

namespace EasyRepair.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
