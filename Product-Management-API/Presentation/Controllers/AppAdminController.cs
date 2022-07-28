using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AppAdminController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public AppAdminController(IRepositoryManager repositoryManager)
        {
            _repository = repositoryManager;
        }
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            
            try
            {
                if (userForRegistration == null) return BadRequest("User is null");
                //Register user if the dto is not null
                var result = await _repository.AppAdmin.RegisterUserAsync(userForRegistration);

                //return user if registration is successful
                return Ok(result);
            }
                    catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            //check if user exist
            if (!await _repository.AppAdmin.ValidateUser(user))
            return Unauthorized();
            //return token if user exists and is validated
            return Ok(new { Token = await _repository.AppAdmin.CreateToken() });
        }
    }
}
