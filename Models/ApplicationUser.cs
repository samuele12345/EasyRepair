using Microsoft.AspNetCore.Identity;

namespace EasyRepair.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirtName { get; set; }
        public string? LastName { get; set; }
    }
}
