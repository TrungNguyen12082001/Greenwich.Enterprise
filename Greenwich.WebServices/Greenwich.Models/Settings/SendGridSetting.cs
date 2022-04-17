namespace Greenwich.Models.Settings
{
    public interface ISendGridSetting
    { 
        string ApiKey { get; }
        string SendFrom { get; }
    }

    public class SendGridSetting : ISendGridSetting
    {
        public string ApiKey { get; set; } = default!;
        public string SendFrom { get; set; } = default!;
    }
}
