using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Greenwich.Enterprise.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class IdeaController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubmissionService _submissionService;
        private readonly IIdeaService _ideaService;
        private readonly ICommentService _commentService;
        private readonly IReplyService _replyService;
        private ILogger<IdeaController> _logger;

        public IdeaController(ICategoryService categoryService,
            ISubmissionService submissionService,
            IIdeaService ideaService,
            ICommentService commentService,
            IReplyService replyService,
            ILogger<IdeaController> logger)
        { 
            _categoryService = categoryService;
            _submissionService = submissionService;
            _ideaService = ideaService;
            _commentService = commentService;
            _replyService = replyService;
            _logger = logger;
        }

        #region Others

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest request)
        { 
            var response = await _categoryService.CreateCategoryAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategoriesAsync();
            return Ok(response);
        }

        [HttpPost("CreateSubmissionRequest")]
        public async Task<IActionResult> CreateSubmission([FromBody] CreateSubmissionRequest request)
        {
            var response = await _submissionService.CreateSubmission(request);
            return Ok(response);
        }

        [HttpGet("GetAllSubmissions")]
        public async Task<IActionResult> GetAllSubmissions()
        {
            var response = await _submissionService.GetSubmissionsAsync();
            return Ok(response);
        }

        #endregion

        #region Hanle Post, Comment, Reply

        [HttpPost("CreateIdea")]
        public async Task<IActionResult> CreateIdea([FromBody] CreateIdeaRequest request)
        {
            var response = await _ideaService.CreateIdeaAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAllIdeas/{submissionId}")]
        public async Task<IActionResult> GetAllIdeas(int submissionId)
        {
            var response = await _ideaService.GetALlIdeasAsync(submissionId);
            return Ok(response);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentRequest request)
        {
            var response = await _commentService.CreateCommentAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAllComments/{ideaId}")]
        public async Task<IActionResult> GetAllComments(int ideaId)
        {
            var response = await _commentService.GetCommentsAsync(ideaId);
            return Ok(response);
        }

        [HttpPost("CreateReply")]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyRequest request)
        {
            var response = await _replyService.CreateReplyAsync(request);
            return Ok(response);
        }

        [HttpGet("GetAllReplies/{commentId}")]
        public async Task<IActionResult> GetAllReplies(int commentId)
        {
            var response = await _replyService.GetRepliesAsync(commentId);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdea(int id)
        {
            var response = await _ideaService.GetIdeaByIdAsync(id);
            return Ok(response);
        }

        #endregion
    }
}
