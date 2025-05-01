using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogReact.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        public string AuthorId { get; set; } = string.Empty;

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser? Author { get; set; }

        // Navigation property for comments
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();


    }
}
