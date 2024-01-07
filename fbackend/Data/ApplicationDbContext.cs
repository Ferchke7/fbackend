using fbackend.Models;
using Microsoft.EntityFrameworkCore;

namespace fbackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Users> Users { get; set; }
        
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PostComments> PostComments { get; set; }
        public DbSet<PostCommentsReplies> PostCommentsReplies { get; set;}

        public DbSet<Routine> Routines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .HasMany(c => c.PostsComments)
                .WithOne(e => e.Blog);
        }

    }
}
