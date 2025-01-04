namespace BlogPost.Application.Common;

public abstract class FileNameGenerator
{
    public static string GenerateMarkDownFileName(string postTitle)
    {
        var shortenedTitle = postTitle.Length > 10 ? postTitle[..10] : postTitle;
        var submitDate = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        var random = Guid.NewGuid().ToString("N");

        return $"{shortenedTitle}--{submitDate}--{random}.md";
    }
}