using tparf.Domain.Entites;

namespace tparf.Interfaces
{
    public interface IUserRepositories
    {
        ICollection<User> GetUsers();
        User GetUser(string userEmail);
        ICollection<Order> GetOrdersByUser(string userEmail);
        ICollection<Product> GetProductByUser(string userEmail);
        decimal GetTotalPrice(string userEmail);
        bool UserExists(string userEmail);
    }
}
