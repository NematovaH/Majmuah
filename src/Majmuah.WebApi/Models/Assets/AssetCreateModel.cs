using Majmuah.Service.Configurations;

namespace Majmuah.WebApi.Models.Assets;

public class AssetCreateModel
{
    public IFormFile File { get; set; }
    public FileType FileType { get; set; }
}