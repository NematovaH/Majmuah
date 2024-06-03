using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Collections;

namespace Majmuah.Domain.Entities.Categories;

public class Category : Auditable
{
    public string Name { get; set; }
    public IEnumerable<Collection> Collections { get; set; }
}