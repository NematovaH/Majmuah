using Majmuah.Service.Helpers;
using Newtonsoft.Json;

namespace Majmuah.Service.Configurations;

[JsonConverter(typeof(EnumStringConverter))]
public enum FileType
{
    Pictures = 1,
    Videos,
    Audios
}