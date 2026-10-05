using EasyRepair.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EasyRepair.Data
{
    public class EasyRepairContext : IdentityDbContext<ApplicationUser>
    {
        public EasyRepairContext(DbContextOptions<EasyRepairContext> options) : base(options)
        {

        }
    }
}
