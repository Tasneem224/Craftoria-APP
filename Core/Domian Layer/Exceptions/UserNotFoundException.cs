using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian_Layer.Exceptions
{
    public sealed class UserNotFoundException(string email) : NotFoundException($"Email '{email}' not found ,Create a new Account")
    {

    }
}
