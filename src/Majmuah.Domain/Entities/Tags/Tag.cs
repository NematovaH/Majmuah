using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Items;

namespace Majmuah.Domain.Entities.Tags;

public class Tag : Auditable
{
    public string Name { get; set; }
    public IEnumerable<ItemTag> ItemTags { get; set; }
}