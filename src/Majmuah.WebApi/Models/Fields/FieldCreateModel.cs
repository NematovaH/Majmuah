using Majmuah.Domain.Enums;

namespace Majmuah.WebApi.Models.Fields;

public class FieldCreateModel
{
    public string Name { get; set; }
    public FieldType FieldType { get; set; }
    public long CollectionId { get; set; }
}