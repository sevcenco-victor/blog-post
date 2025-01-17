using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Tags.Commands.CreateTag;
using BlogPost.Application.Tags.Common;
using BlogPost.Domain.Tags;

namespace BlogPost.Application.Mapper;

public static class TagMapperExtension
{
    public static Tag ToEntity(this CreateTagRequest tagRequest)
    {
        return new Tag()
        {
            Name = tagRequest.Name,
            Color = tagRequest.Color
        };
    }

    public static TagResponse ToTagResponse(this Tag tag)
    {
        return new TagResponse(tag.Id, tag.Name, tag.Color);
    }

    public static Tag ToEntity(this UpdateTagRequest tagRequest)
    {
        return new Tag()
        {
            Name = tagRequest.Name,
            Color = tagRequest.Color
        };
    }
}