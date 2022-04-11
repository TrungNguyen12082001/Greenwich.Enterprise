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
    public class ViewMonitoringController : ControllerBase
    {
        private readonly IViewMonitoringService _viewMonitoringService;

        public ViewMonitoringController(IViewMonitoringService viewMonitoringService)
        { 
            _viewMonitoringService = viewMonitoringService;
        }

        [HttpPost("CreateView")]
        public async Task<IActionResult> CreateView([FromBody] CreateViewRequest request)
        {
            var response = await _viewMonitoringService.CreateView(request);
            return Ok(response);
        }

        [HttpGet("GetViewCount/{ideaId}")]
        public async Task<IActionResult> GetViewCount(int ideaId)
        {
            var response = await _viewMonitoringService.GetViewCountByIdeadId(ideaId);
            return Ok(response);
        }
    }
}
