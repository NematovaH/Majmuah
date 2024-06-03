using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Enums;

namespace Majmuah.Domain.Entities.Fields;

public class Field : Auditable
{
    public string Name { get; set; }
    public FieldType FieldType { get; set; }
    public long CollectionId { get; set; }
    public Collection Collection { get; set; }
}