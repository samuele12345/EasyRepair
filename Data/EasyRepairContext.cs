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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrdItem)
                .HasForeignKey(fk => fk.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(i => i.Item)
                .WithMany(oi => oi.OrdItem)
                .HasForeignKey(fk => fk.ItemId);

            builder.Entity<Order>()
                .HasOne(u => u.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(fk => fk.UserId);
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
