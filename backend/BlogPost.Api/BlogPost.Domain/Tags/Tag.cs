using System.Text.Json.Serialization;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;

namespace BlogPost.Domain.Tags;

public class Tag : Entity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    [JsonIgnore] public IEnumerable<Post> Blogs { get; set; } = new List<Post>();
}