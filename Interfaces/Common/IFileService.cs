using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FastFood.Interfaces.Common;

public interface IFileService
{
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<string> DeleteImageAsync(IFormFile subpath);

    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<string> DeleteAvatarAsync(IFormFile subpath);
}
