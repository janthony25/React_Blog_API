using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogReact.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Foreigh key for the user who created the comment
        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        // Foreign key for the post this comment belongs to
        [Required]
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

        // Navigation property for replies to comment
        public ICollection<Reply> Replies { get; set; } = new List<Reply>();
    }
}
