using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Contracts.Tag;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Mapper;

public static class TagMapperExtension
{
    public static Tag ToEntity(this CreateTagRequest tagRequest)
    {
        return new Tag()
        {
            Name = tagRequest.Name,
        };
    }

    public static TagResponse ToTagResponse(this Tag tag)
    {
        return new TagResponse(tag.Id, tag.Name);
    }

    public static Tag ToEntity(this UpdateTagRequest tagRequest)
    {
        return new Tag()
        {
            Name = tagRequest.Name,
        };
    }
}