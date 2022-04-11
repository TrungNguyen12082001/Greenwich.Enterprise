using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("Replies")]
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CommentId { get; set; }

        [DataType("nvarchar"), MaxLength(8000)]
        public string Content { get; set; } = string.Empty;

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
