using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Domain.Entities.Tags;

namespace Majmuah.Domain.Entities.Items;

public class Item : Auditable
{
    public string Name { get; set; }
    public long CollectionId {  get; set; }
    public Collection Collection { get; set; }
    public IEnumerable<ItemTag> ItemTags { get; set; }
    public IEnumerable<Like> Likes { get; set; }
    public IEnumerable<FieldValue> FieldValues { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
}