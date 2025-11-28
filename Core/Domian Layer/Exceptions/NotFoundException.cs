using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian_Layer.Exceptions
{
    public  class NotFoundException(string email) : Exception
    {
    }
}
