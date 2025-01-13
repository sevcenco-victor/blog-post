using Microsoft.AspNetCore.Http;

namespace BlogPost.Application.Abstractions;

public interface ICloudStorageService
{
    Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes = 1,
        CancellationToken cancellationToken = default);

    Task<string> UploadFileAsync(IFormFile fileToUpload, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(string fileNameToDelete, CancellationToken cancellationToken);
}