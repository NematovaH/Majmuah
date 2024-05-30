using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Users;

namespace Majmuah.Domain.Entities.Comments;

public class Comment : Auditable
{
    public string Content { get; set; }
    public DateTime Time { get; set; }
    public long ItemId { get; set; }
    public Item Item { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long? ParentId { get; set; }
    public Comment Parent { get; set; }
    public ICollection<Comment> Replies { get; set; }
}