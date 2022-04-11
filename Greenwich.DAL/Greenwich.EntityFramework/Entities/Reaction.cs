using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Greenwich.EntityFramework.Entities
{
    [Table("Reactions")]
    public class Reaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdeaId { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
