using BlogReact.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogReact.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }   


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure reply entity to handle self-referencing relationship
            builder.Entity<Reply>()
                .HasOne(r => r.ParentReply)
                .WithMany(r => r.ChildReplies)
                .HasForeignKey(r => r.ParentReplyId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete cycles

            // Configure comment and reply relationship
            builder.Entity<Reply>()
                .HasOne(r => r.Comment)
                .WithMany(c => c.Replies)
                .HasForeignKey(r => r.CommentId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete cycles
        }
    }
}
