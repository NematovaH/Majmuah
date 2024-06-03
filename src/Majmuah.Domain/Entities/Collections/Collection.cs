using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Categories;
using Majmuah.Domain.Entities.Commons;
using Majmuah.Domain.Entities.Fields;
using Majmuah.Domain.Entities.Items;
using Majmuah.Domain.Entities.Users;

namespace Majmuah.Domain.Entities.Collections;

public class Collection : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long? AssetId { get; set; }
    public Asset Asset { get; set; }
    public IEnumerable<Item> Items { get; set; }
    public IEnumerable<Field> Fields { get; set; }
}