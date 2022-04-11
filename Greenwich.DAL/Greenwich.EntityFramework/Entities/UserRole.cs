using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("varchar"), MaxLength(50)]
        public string Name { get; set; }
    }
}
