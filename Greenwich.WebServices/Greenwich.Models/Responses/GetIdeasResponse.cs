namespace Greenwich.Models.Responses
{
    public class GetIdeasResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime FinalClosureDate { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }
    }
}
