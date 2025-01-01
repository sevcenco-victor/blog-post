using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Entities;

namespace BlogPost.Application.Mapper;

public static class PostMapperExtension
{
    public static Post ToEntity(this CreatePostRequest post)
    {
        return new Post()
        {
            Title = post.Title,
            Text = post.Text,
            PostDate = DateOnly.FromDateTime(DateTime.Now.ToUniversalTime()),
            LastEdit = DateTime.Now.ToUniversalTime(),
            ImageUrl = post.ImageUrl,
        };
    }
    
    public static CreatePostRequest ToCreatePostDto(this Post post)
    {
        return new CreatePostRequest(post.Title, post.Text, post.ImageUrl, post.Tags.Select(t => t.Id));
    }

    public static Post ToEntity(this PostResponse post)
    {
        return new Post()
        {
            Id = post.Id,
            Title = post.Title,
            Text = post.Text,
            PostDate = post.PostDate,
            LastEdit = post.LastEdit,
            ImageUrl = post.ImageUrl
        };
    }

    public static PostResponse ToPostResponseDto(this Post post)
    {
        return new PostResponse(post.Id, post.Title, post.Text, post.PostDate, post.LastEdit, post.ImageUrl, post.Tags);
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