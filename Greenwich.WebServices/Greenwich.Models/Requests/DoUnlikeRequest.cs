namespace Greenwich.Models.Requests
{
    public class DoUnlikeRequest
    {
        public int IdeaId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
    }
}
