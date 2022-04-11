using System.ComponentModel.DataAnnotations;

namespace Greenwich.Models.Requests
{
    public class CreateIdeaRequest
    {
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        public string Content { get; set; }   
        
        public int UserId { get; set; }       
        
        public int CategoryId { get; set; }

        public int SubmissionId { get; set; }
    }
}
