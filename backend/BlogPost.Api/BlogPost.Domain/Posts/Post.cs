using BlogPost.Domain.Primitives;
using BlogPost.Domain.Tags;
using BlogPost.Domain.Users;

namespace BlogPost.Domain.Posts;

public class Post : Entity<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateOnly PostDate { get; set; }
    public DateTime LastEdit { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string MarkdownFileName { get; set; } = string.Empty;
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public Guid UserId { get; set; }
    public User User { get; set; }
}