using Microsoft.AspNetCore.Http;

namespace BlogPost.Application.Abstractions;

public interface ICloudStorageService
{
    Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 1);
    Task<string> UploadFileAsync(IFormFile fileToUpload);
    Task DeleteFileAsync(string fileNameToDelete);
}