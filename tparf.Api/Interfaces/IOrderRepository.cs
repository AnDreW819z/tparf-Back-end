using tparf.Domain.Entites;

namespace tparf.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrder(int orderId);
        ICollection<Order> GetOrdersOfAUser(string userEmail);
        ICollection<Order> GetOrdersOfAProduct(int productId);
        bool OrderExists(int orderId);
        bool CreateOrder(string userEmail, int productId,Order order);
        bool Save();
    }
}
