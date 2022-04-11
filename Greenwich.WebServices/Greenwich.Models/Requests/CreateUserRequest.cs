using System.ComponentModel.DataAnnotations;

namespace Greenwich.Models.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }                 
               
    }
}
