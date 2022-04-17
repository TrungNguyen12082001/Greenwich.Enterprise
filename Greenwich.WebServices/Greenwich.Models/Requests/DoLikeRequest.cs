namespace Greenwich.Models.Requests
{
    public class DoLikeRequest
    {
        public int CommentId { get; set; }
        public int IdeaId { get; set; }
        public int UserId { get; set; }
    }
}
