namespace Greenwich.Models
{
    public class UpdateUserModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class LoginModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
