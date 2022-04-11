using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.EntityFramework
{
    public class GEWDbcontext : DbContext
    {
        public GEWDbcontext(DbContextOptions<GEWDbcontext> options) : base(options)
        {
        }
     
        public DbSet<User> Users { get; set; }       
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Department> Departments { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<FileSubmission> FileSubmissions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<ViewMonitoring> ViewMonitorings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}
