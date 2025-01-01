using System.Text.Json.Serialization;
using BlogPost.Domain.Primitives;

namespace BlogPost.Domain.Entities;

public class Tag : Entity
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    [JsonIgnore] public IEnumerable<Post> Blogs { get; set; } = new List<Post>();
}