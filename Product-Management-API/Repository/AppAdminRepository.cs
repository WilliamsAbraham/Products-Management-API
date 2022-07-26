using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
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
        private AppAdmin? _appAdmin;

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
        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _appAdmin = await _userManager.FindByEmailAsync(userForAuth.Email);
            var result = (_appAdmin != null &&  await _userManager.CheckPasswordAsync(_appAdmin, userForAuth.Password)); 
            if(result)
                return true;
                return result;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);

        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            { new Claim(ClaimTypes.Name,_appAdmin.Email)};
            var roles = await _userManager.GetRolesAsync(_appAdmin);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
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
