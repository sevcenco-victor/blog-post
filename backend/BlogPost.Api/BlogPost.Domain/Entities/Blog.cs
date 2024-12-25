namespace BlogPost.Domain.Entities;

public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateOnly PostDate { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
}