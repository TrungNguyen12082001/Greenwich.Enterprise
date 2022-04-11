using System.ComponentModel.DataAnnotations;

namespace Greenwich.Models.Requests
{
    public class CreateCommentRequest
    {
        public  int IdeaId { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
