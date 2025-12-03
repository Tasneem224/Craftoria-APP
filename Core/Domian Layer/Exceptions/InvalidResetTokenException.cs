using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian_Layer.Exceptions
{
    public class InvalidResetTokenException : Exception
    {
        public InvalidResetTokenException()
            : base("Invalid or expired password reset token.")
        {
        }
    }
}
