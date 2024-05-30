using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Users;

namespace Majmuah.Domain.Entities.Likes;

public class Like : Auditable
{
    public long ItemId {  get; set; }
    public Item Item { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}