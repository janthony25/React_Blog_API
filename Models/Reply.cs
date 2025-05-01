using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogReact.Models
{
    public class Reply
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        // Foreign key for the user who created the reply
        [Required]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        // Foreign key for the comment this reply belongs to
        public int? CommentId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        // For nested replies
        public int ParentReplyId { get; set; }

        [ForeignKey("ParentReplyId")]
        public Reply ParentReply { get; set; }

        // Collection of child replies
        public ICollection<Reply> ChildReplies { get; set; } = new List<Reply>();
    }
}
