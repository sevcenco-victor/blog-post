namespace BlogPost.Infrastructure.ConfigOptions;

public class GCSConfigOptions
{
    public string? GCPStorageAuthFile { get; set; } = string.Empty;
    public string? GCSBucketName { get; set; } = string.Empty;
}