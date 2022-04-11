using System.ComponentModel.DataAnnotations;

namespace Greenwich.Models.Responses
{
    internal class CreateUserResponse
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
