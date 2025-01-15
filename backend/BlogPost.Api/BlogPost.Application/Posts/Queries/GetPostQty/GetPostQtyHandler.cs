using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostQty;

public sealed class GetPostQtyHandler : IRequestHandler<GetPostQtyQuery, Result<int>>
{
    private readonly IPostRepository _postRepository;

    public GetPostQtyHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<int>> Handle(GetPostQtyQuery request, CancellationToken cancellationToken)
    {
        var qty = await _postRepository.GetPostCountAsync(cancellationToken);
        return Result<int>.Success(qty);
    }
}