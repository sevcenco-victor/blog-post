using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Mapper;

public static class PostMapperExtension
{
    public static Post ToEntity(this CreatePostRequest post, IEnumerable<Tag> tags, string markdownFileName )
    {
        return new Post()
        {
            Title = post.Title,
            Text = post.Text,
            PostDate = DateOnly.FromDateTime(DateTime.Now.ToUniversalTime()),
            LastEdit = DateTime.Now.ToUniversalTime(),
            MarkdownFileName = markdownFileName,
            Tags = tags.ToList(),
            ImageUrl = post.ImageUrl,
        };
    }

    public static PostResponse ToPostResponseDto(this Post post)
    {
        return new PostResponse(
            post.Id,
            post.Title,
            post.Text,
            post.PostDate,
            post.ImageUrl,
            post.Tags);
    }

    public static DetailedPostResponse ToDetailedPostResponseDto(this Post post, string markdownFileLink)
    {
        return new DetailedPostResponse(
            post.Id,
            post.Title,
            post.Text,
            post.PostDate,
            post.LastEdit,
            post.ImageUrl,
            markdownFileLink,
            post.Tags);
    }

    public static Post ToEntity(this UpdatePostRequest post)
    {
        return new Post()
        {
            Title = post.Title,
            Text = post.Text,
            LastEdit = DateTime.Now.ToUniversalTime(),
            ImageUrl = post.ImageUrl,
        };
    }
}