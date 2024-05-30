using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Tags;

namespace Majmuah.Domain.Entities.Items;

public class ItemTag : Auditable
{
    public long ItemId { get; set; }
    public Item Item { get; set; }
    public long TagId { get; set; }
    public Tag Tag { get; set; }
}