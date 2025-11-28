using Abstraction_Layer;
using Domian_Layer.Models.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer
{
    public class ServiceManager(UserManager<ApplicationUser> _userManager, IConfiguration _configuration, ICloudinaryService _cloudinaryService) : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _LazyAuthenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_userManager, _configuration, _cloudinaryService));

        public IAuthenticationService AuthenticationService => _LazyAuthenticationService.Value;
    
    }
}
