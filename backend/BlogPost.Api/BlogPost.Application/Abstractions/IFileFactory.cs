using Microsoft.AspNetCore.Http;

namespace BlogPost.Application.Abstractions;

public interface IFileFactory
{
    IFormFile CreateInMemoryFile(string content, string fileName);
}