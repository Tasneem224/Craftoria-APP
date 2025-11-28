using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian_Layer.Exceptions
{
    public sealed class BadRequestException(List<string> errors) : Exception("Validation failed")

    {
        public List<string> Errors { get; } = errors;
    }
}
