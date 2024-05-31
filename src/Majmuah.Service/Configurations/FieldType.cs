using Majmuah.Service.Helpers;
using System.Text.Json.Serialization;

namespace Majmuah.Domain.Enums;

[JsonConverter(typeof(EnumStringConverter))]
public enum FieldType
{
    Integer,
    String,
    Boolean,
    DateTime
}