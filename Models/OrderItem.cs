using System.ComponentModel.DataAnnotations.Schema;

namespace EasyRepair.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("ItemId")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public decimal PriceSnapshot { get; set; }
    }
}
