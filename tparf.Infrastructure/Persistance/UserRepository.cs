using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tparf.Application.Services.Common.Interfaces.Persistance;
using tparf.Domain.Entites;

namespace tparf.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
           return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
