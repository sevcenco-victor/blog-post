using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Posts.Commands.CreatePost;
using BlogPost.Application.Posts.Common;
using BlogPost.Application.Posts.Queries.GetPostById;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Tags;

namespace BlogPost.Application.Mapper;

public static class PostMapperExtension
{
    public static Post ToEntity(this CreatePostRequest post, IEnumerable<Tag> tags, string markdownFileName)
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
            UserId = post.UserId,
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
            post.Tags,
            post.User.Username
        );
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