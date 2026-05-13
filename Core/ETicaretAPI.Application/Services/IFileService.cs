using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Services
{
    public interface IFileService
    {

        Task<List<(string fileName,string path)>> uploadAsync(string path,IFormFileCollection files);

        Task<bool> CopyFileAsync(string path,IFormFile file);
    }
}
