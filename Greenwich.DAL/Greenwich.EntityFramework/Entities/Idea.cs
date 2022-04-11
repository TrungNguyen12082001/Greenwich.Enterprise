using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("Ideas")]
    public class Idea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("nvarchar"), MaxLength(500)]
        public string Title { get; set; } = string.Empty;

        [DataType("nvarchar"), MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [DataType("nvarchar"), MaxLength(8000)]
        public string Content { get; set; } = string.Empty;

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CategoryId { get; set; }

        public int SubmissionId { get; set; }
    }
}
