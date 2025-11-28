using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction_Layer
{
    public interface IAuthenticationService
    {
        Task<ReturnUserDTO> RegisterAsync(RegisterDto RegisterDto);


    }
}
