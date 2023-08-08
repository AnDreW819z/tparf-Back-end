using System.ComponentModel.DataAnnotations;
using tparf.Domain.Entites;
namespace tparf.Domain.Entites
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrdersDate { get; set; }
        public OrderStatus Status { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Product Product { get; set; }
    }
    public enum OrderStatus
    {
        Ordered,
        Paid,
        Canceled

    }
}
