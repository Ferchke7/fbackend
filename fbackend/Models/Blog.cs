using System.ComponentModel.DataAnnotations.Schema;

namespace fbackend.Models
{
    public class Blog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string TitleName { get; set; }
        
        public string Author { get; set; }
        public int Visiters { get; set; }

        public int Likes { get; set; }

        public string Description { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;

        public ICollection<PostComments> PostsComments { get; set;} = new List<PostComments>();

    }
}
