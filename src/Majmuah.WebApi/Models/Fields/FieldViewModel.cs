using Majmuah.Domain.Enums;

namespace Majmuah.WebApi.Models.Fields;

public class FieldViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public FieldType FieldType { get; set; }
    public long CollectionId { get; set; }
}