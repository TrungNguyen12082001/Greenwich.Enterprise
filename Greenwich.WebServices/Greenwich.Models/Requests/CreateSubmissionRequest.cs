namespace Greenwich.Models.Requests
{
    public class CreateSubmissionRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime ClosureDate { get; set; }
        public DateTime FinalClosureDate { get; set; }
    }
}
