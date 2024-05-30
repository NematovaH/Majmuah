using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Items;

namespace Majmuah.Domain.Entities.Fields;

public class FieldValue : Auditable
{
    public string Value { get; set; }
    public long ItemId {  get; set; }
    public Item Item { get; set; }
    public long FieldId {  get; set; }
    public Field Field { get; set; }
}