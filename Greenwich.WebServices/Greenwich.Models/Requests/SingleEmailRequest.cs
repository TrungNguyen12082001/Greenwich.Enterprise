namespace Greenwich.Models.Requests
{
    public class SingleEmailRequest
    {
        public string ToEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string PlaintextContent { get; set; } = string.Empty;
        public string HtmlContent { get; set; } = string.Empty;
    }
}
