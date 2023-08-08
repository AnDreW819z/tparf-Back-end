using AutoMapper;
using tparf.Data;
using tparf.Interfaces;
using tparf.Domain.Entites;

namespace tparf.Repository
{
    public class UserRepository : IUserRepositories
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICollection<Order> GetOrdersByUser(string userEmail)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userEmail)
        {
            return _context.Users.Where(r => r.Email == userEmail).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UserExists(string userEmail)
        {
            return _context.Users.Any(o => o.Email == userEmail);
        }

        public ICollection<Product> GetProductByUser(string userEmail)
        {
            return _context.Orders.Where(p => p.User.Email == userEmail).Select(p => p.Product).ToList();
        }

        public decimal GetTotalPrice(string userEmail)
        {
            var userTotalPrice = _context.Orders.Where(u => u.User.Email == userEmail);
            if (userTotalPrice.Count() == 0)
                return 0;
            return (decimal)userTotalPrice.Sum(p => p.Product.Price);
        }
    }
}
