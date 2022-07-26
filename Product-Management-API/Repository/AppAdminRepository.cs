using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AppAdminRepository : IAppAdminRepository
    { private readonly RepositoryContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppAdmin> _userManager;
        private readonly IConfiguration _configuration;

        public AppAdminRepository(RepositoryContext context, IMapper mapper,UserManager<AppAdmin> userManager, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<AppAdmin>(userForRegistration);
            var result = await _userManager.CreateAsync(user,userForRegistration.Password);
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, userForRegistration.Role);

            return
                result;
        }
        public Task<string> CreateToken()
        {
            throw new NotImplementedException();
        }
        public Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            throw new NotImplementedException();
        }
    }
}
