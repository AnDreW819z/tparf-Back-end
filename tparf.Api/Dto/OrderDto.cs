using tparf.Domain.Entites;

namespace tparf.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}
