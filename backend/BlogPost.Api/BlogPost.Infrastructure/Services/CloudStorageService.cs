using BlogPost.Application.Abstractions;
using BlogPost.Infrastructure.ConfigOptions;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlogPost.Infrastructure.Services;

public class CloudStorageService : ICloudStorageService
{
    private readonly IOptions<GcsSettings> _options;
    private readonly ILogger<CloudStorageService> _logger;
    private readonly GoogleCredential _credential;

    public CloudStorageService(IOptions<GcsSettings> options, ILogger<CloudStorageService> logger)
    {
        _options = options;
        _logger = logger;
        _credential = GoogleCredential.FromFile(_options.Value.GCPStorageAuthFile);
    }

    public async Task<string> GetSignedUrlAsync(string fileNameToRead, int timeOutInMinutes,
        CancellationToken cancellationToken)
    {
        var bucketName = _options.Value.GCSBucketName;

        var sac = _credential.UnderlyingCredential as ServiceAccountCredential;
        var urlSigner = UrlSigner.FromCredential(sac);
        var signedUrl = await urlSigner.SignAsync(bucketName, fileNameToRead, TimeSpan.FromMinutes(timeOutInMinutes),
            cancellationToken: cancellationToken);

        return signedUrl;
    }

    public async Task<string> UploadFileAsync(IFormFile fileToUpload, CancellationToken cancellationToken)
    {
        var bucketName = _options.Value.GCSBucketName;
        var fileName = fileToUpload.FileName;

        _logger.LogInformation("Uploading file {fileName} to bucket {bucketName}", fileName, bucketName);
        using var stream = new MemoryStream();
        await fileToUpload.CopyToAsync(stream, cancellationToken);

        stream.Position = 0;

        using var storageClient = await StorageClient.CreateAsync(_credential);

        var uploadedFile = await storageClient.UploadObjectAsync(bucketName, fileName,
            fileToUpload.ContentType, stream, cancellationToken: cancellationToken);
        _logger.LogInformation("Uploaded: file {fileName} to bucket {bucketName}", fileName, bucketName);


        return uploadedFile.MediaLink;
    }

    public async Task DeleteFileAsync(string fileNameToDelete, CancellationToken cancellationToken)
    {
        var bucketName = _options.Value.GCSBucketName;

        _logger.LogInformation("Deleting file {fileNameToDelete}", fileNameToDelete);
        using var storageClient = await StorageClient.CreateAsync(_credential);

        await storageClient.DeleteObjectAsync(bucketName, fileNameToDelete, cancellationToken: cancellationToken);
        _logger.LogInformation("Deleted file {fileNameToDelete}", fileNameToDelete);
    }
}