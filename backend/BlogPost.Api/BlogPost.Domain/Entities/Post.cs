using BlogPost.Domain.Primitives;

namespace BlogPost.Domain.Entities;

public class Post : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateOnly PostDate { get; set; }
    public DateTime LastEdit { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string MarkdownFileName { get; set; } = string.Empty;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}