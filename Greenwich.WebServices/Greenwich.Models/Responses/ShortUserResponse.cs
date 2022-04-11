namespace Greenwich.Models.Responses
{
    public class ShortUserResponse
    {
        public int UserId { get; set; }        
        public string RoleName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string AvatarUrl { get; set; }
        public string Department { get; set; }
    }
}
