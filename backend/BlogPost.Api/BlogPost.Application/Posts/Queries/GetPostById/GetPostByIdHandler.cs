using BlogPost.Application.Abstractions;
using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostById;

public sealed class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Result<DetailedPostResponse>>
{
    private readonly IPostRepository _postRepository;
    private readonly ICloudStorageService _cloudStorageService;

    public GetPostByIdHandler(IPostRepository postRepository, ICloudStorageService cloudStorageService)
    {
        _postRepository = postRepository;
        _cloudStorageService = cloudStorageService;
    }

    public async Task<Result<DetailedPostResponse>> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var postId = query.Id;
        var post = await _postRepository.GetByIdAsync(postId,cancellationToken);

        if (post == null)
        {
            return Result<DetailedPostResponse>.Failure(PostErrors.NotFoundById(postId));
        }

        var markdownFileLink =
            await _cloudStorageService.GetSignedUrlAsync(post.MarkdownFileName, cancellationToken: cancellationToken);

        return Result<DetailedPostResponse>.Success(post.ToDetailedPostResponseDto(markdownFileLink));
    }
}