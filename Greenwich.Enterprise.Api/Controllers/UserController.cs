using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Greenwich.Enterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Constructor

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Public Functions

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetALlUsersAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromBody] CreateUserRequest model)
        {
            var response = await _userService.CreateUserAsync(model);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUser([FromBody] User model)
        {
            var response = await _userService.UpdateUserAsync(model);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUserAsync(id);
            return Ok(response);
        }

        #endregion

    }
}
