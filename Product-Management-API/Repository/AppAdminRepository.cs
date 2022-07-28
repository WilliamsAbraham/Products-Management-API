using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repository
{
    public class AppAdminRepository : IAppAdminRepository
    { private readonly RepositoryContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppAdmin> _userManager;
        private readonly SignInManager<AppAdmin> _singInManagerManager;
        private readonly IConfiguration _configuration;
        private AppAdmin? _appAdmin;

        public AppAdminRepository(RepositoryContext context, IMapper mapper, UserManager<AppAdmin> userManager, IConfiguration configuration, SignInManager<AppAdmin> singInManagerManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _singInManagerManager = singInManagerManager;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserForRegistrationDto userForRegistration)
        {
            //mapping the registrationDto to the AppAdmin entities
            var user = _mapper.Map<AppAdmin>(userForRegistration);
            // concatenating the first and last names to form the Username 
            user.UserName = user.FirstName + user.LastName;
            var result = await _userManager.CreateAsync(user,userForRegistration.Password);
            if (!result.Succeeded)
                throw new Exception($"{result.Errors}");
            //on successful user creation, add user to the database
                await _userManager.AddToRoleAsync(user, userForRegistration.Role);

            return 
                //return created user
                result;
        }
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            //checking if user exists by email
            _appAdmin = await _userManager.FindByEmailAsync(userForAuth.Email);
            var result = (_appAdmin != null &&  await _userManager.CheckPasswordAsync(_appAdmin, userForAuth.Password));
            //throw an exception if user does not exist
            if (!result)
                throw new Exception("User was not found");
            //return result if user exists
                return result;
        }
        public async Task<string> CreateToken()
        {
            //asignning the result from method GetSigningCredentials to the variable signingCredentials
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            // parsing in the signingCredentials and the claims variables to the GenerateTokenOptions method 
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            //extracting the jwt key from the environment variable and storing it in the key variable
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            //creating and returning the SigningCredentials
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);

        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            //creating a list of claims
            { new Claim(ClaimTypes.Name,_appAdmin.Email)};
            var roles = await _userManager.GetRolesAsync(_appAdmin);
            //adding role claim types to the list of cliams
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            //populating the jwt securitytoken properties
            var tokenOptions = new JwtSecurityToken 
                (
                issuer:jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
                );
            return tokenOptions;

        }
       
    }
}
