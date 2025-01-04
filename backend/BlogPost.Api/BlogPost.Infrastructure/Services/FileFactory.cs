using System.Text;
using BlogPost.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace BlogPost.Infrastructure.Services;

public class FileFactory : IFileFactory
{
    public IFormFile CreateInMemoryFile(string content, string fileName)
    {
        var stream = new MemoryStream(Encoding.UTF8.GetBytes(content));
        var formFile = new FormFile(stream, 0, stream.Length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = "text/markdown",
        };

        return formFile;
    }
}