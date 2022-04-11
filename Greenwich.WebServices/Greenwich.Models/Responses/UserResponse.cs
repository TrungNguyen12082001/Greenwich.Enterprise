namespace Greenwich.Models.Responses
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public int? DepartmentId { get; set; }
        public int UserRoleId { get; set; }
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
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
