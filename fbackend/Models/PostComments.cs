using System.ComponentModel.DataAnnotations.Schema;

namespace fbackend.Models
{
    public class PostComments
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        
        public int PostId { get; set; }

        public int UserId { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public int likes { get; set; }


        public ICollection<PostCommentsReplies> CommentsReplies { get; set;}

    }
}
