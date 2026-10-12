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

            builder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Samsung S23",
                    Price = 280m,
                    Image = "/imgs/pexels-rubaitulazad-16149966.jpg",
                    Tipo = ItemType.Device
                },

                new Item
                {
                    Id = 2,
                    Name = "Samsung S22",
                    Price = 215m,
                    Image = "/imgs/pexels-rubaitulazad-16149966.jpg",
                    Tipo = ItemType.Device
                },

                new Item
                {
                    Id = 3,
                    Name = "Batteria s23",
                    Price = 170m,
                    Image = "/imgs/pexels-rubaitulazad-16149966.jpg",
                    Tipo = ItemType.SparePart
                }
            );
        }



        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
