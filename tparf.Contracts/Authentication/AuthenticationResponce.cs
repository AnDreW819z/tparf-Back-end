using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tparf.Contracts.Authentication
{
    public record AuthenticationResponce(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
