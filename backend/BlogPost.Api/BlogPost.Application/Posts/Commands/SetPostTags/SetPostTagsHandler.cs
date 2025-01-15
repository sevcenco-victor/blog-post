using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Tags;
using MediatR;

namespace BlogPost.Application.Posts.Commands.SetPostTags;

public class SetPostTagsHandler : IRequestHandler<SetPostTagsCommand, Result>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public SetPostTagsHandler(IPostRepository postRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }

    public async Task<Result> Handle(SetPostTagsCommand request, CancellationToken cancellationToken)
    {
        var (postId, tagIds) = request;

        var validPost = await _postRepository.GetByIdAsync(postId, cancellationToken);
        if (validPost == null)
        {
            return Result.Failure(PostErrors.NotFoundById(postId));
        }

        var validTags = await _tagRepository.GetTagsByIdsAsync(tagIds, cancellationToken);

        await _postRepository.SetTagsAsync(request.PostId, validTags, cancellationToken);

        return Result.Success();
    }
}