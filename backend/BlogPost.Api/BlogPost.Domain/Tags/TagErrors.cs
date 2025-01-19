using BlogPost.Domain.Abstractions;

namespace BlogPost.Domain.Tags;

public static class TagErrors
{
    public static Error NotFoundByName(string tagName) => Error.NotFound("Tag.NameNotFound", $"Tag with name {tagName} Not Found");
    public static Error NotFoundById(Guid id) => Error.NotFound("Tag.IdNotFound", $"Tag with id {id} Not Found");

    public static Error NameAlreadyExists(string name) =>
        Error.Conflict("Tag.NameAlreadyExists", $"Tag with name {name} Already Exists");
    
    
}