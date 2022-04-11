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
    public class ReactionController : ControllerBase
    {
        private readonly IReactionService _reactionService;
        public ReactionController(IReactionService reactionService)
        { 
            _reactionService = reactionService;
        }

        [HttpPost("DoLike")]
        public async Task<IActionResult> DoLike([FromBody] DoLikeRequest request)
        { 
            var response = await _reactionService.DoLike(request);
            return Ok(response);
        }

        [HttpPost("DoUnlike")]
        public async Task<IActionResult> DoUnlike([FromBody] DoUnlikeRequest request)
        {
            var response = await _reactionService.DoUnlike(request);
            return Ok(response);
        }

        [HttpGet("GetLikeCount/{ideaId}")]
        public async Task<IActionResult> GetLikeCount(int ideaId)
        {
            var response = await _reactionService.GetLikeCount(ideaId);
            return Ok(response);
        }
    }
}
