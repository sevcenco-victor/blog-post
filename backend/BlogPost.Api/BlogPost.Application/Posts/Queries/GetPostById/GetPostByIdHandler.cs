using BlogPost.Application.Exceptions;
using BlogPost.Application.Mapper;
using BlogPost.Contracts.Post;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostById;

public sealed class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Result<PostResponse>>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository) => _postRepository = postRepository;

    public async Task<Result<PostResponse>> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(query.Id);

        if (post == null)
        {
            var error = new PostNotFoundException($"Post with id {query.Id} not found");
            return new Result<PostResponse>(error);
        }

        return post.ToPostResponseDto();
    }
}