using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("nvarchar"), MaxLength(50)]
        public string FirstName { get; set; }

        [DataType("nvarchar"), MaxLength(50)]
        public string LastName { get; set; }

        [DataType("varchar"), MaxLength(200)]
        public string Email { get; set; }

        [DataType("varchar"), MaxLength(200)]
        public string Password { get; set; }

        [DataType("varchar"), MaxLength(200)]
        public string Salt { get; set; }

        public int RoleId { get; set; }

        public int DepartmentId { get; set; }
        
        public string Avatar { get; set; }        
    }
}
