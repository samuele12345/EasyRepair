using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRepair.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime ordDate { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem>? OrdItem { get; set; }
    }
}
