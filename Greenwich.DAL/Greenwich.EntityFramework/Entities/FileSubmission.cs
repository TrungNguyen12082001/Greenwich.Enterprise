using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("FileSubmissions")]
    public class FileSubmission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType("varchar"), MaxLength(1000)]
        public string? FilePath { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public int IdeaId { get; set; }
    }
}
