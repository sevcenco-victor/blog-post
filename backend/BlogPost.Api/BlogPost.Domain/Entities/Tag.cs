namespace BlogPost.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Blog> Blogs { get; set; } = new List<Blog>();
}