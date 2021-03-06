using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("nvarchar"), MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [DataType("nvarchar"), MaxLength(1000)]
        public string Description { get; set; } = string.Empty;
    }
}
