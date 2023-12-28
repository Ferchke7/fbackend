using System.ComponentModel.DataAnnotations.Schema;

namespace fbackend.Models
{
    public class PostCommentsReplies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostId { get; set; }

        public string Comment { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public int likes { get; set; }
    }
}
