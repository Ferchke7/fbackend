using System.ComponentModel.DataAnnotations.Schema;

namespace fbackend.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<PostComments> Comments { get; set; } = new List<PostComments>();

        public Blog Blog { get; set; } = null!;

    }
}
