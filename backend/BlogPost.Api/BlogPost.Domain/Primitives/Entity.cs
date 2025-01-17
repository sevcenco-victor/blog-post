namespace BlogPost.Domain.Primitives;

public abstract class Entity<TK>
{
    public TK Id { get; set; }

    protected Entity(TK id) => Id = id;

    protected Entity()
    {
    }
}