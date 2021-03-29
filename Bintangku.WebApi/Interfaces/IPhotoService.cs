using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet.Actions;

namespace Bintangku.WebApi.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}