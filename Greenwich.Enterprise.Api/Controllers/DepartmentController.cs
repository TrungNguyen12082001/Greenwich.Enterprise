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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var response = await _departmentService.GetDepartmentsAsync();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewDepartment([FromBody] CreateDepartmentRequest model)
        {
            var response = await _departmentService.CreateNewDepartment(model);

            return Ok(response);
        }
    }
}
