using Contracts;
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
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await
            _repository.AppAdmin.RegisterUserAsync(userForRegistration);
         
                return
                    StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _repository.AppAdmin.ValidateUser(user))
                return Unauthorized();
            return Ok(new { Token = await _repository.AppAdmin.CreateToken() });
            

        }
    }
}
