using Majmuah.Domain.Entities.Commons;
using Majmuah.Service.Configurations;
using Microsoft.AspNetCore.Http;

namespace Majmuah.Service.Services.Assets;

public interface IAssetService
{
    ValueTask<Asset> UploadAsync(IFormFile file, FileType type);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<Asset> GetByIdAsync(long id);
}