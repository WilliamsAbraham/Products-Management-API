using Contracts;
using Microsoft.AspNetCore.Identity;
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
        public AppAdminRepository(RepositoryContext context)
        {
            _context = context;
        }
        public Task<string> CreateToken()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            throw new NotImplementedException();
        }
    }
}
