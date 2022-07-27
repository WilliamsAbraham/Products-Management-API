using Microsoft.AspNetCore.Identity;
using Shared.DataTransferObjects;

namespace Contracts
{
    public interface IAppAdminRepository
    {
        Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();
    }
}
