using BlogPost.Application.Exceptions;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.SetPostTags;

public class SetPostTagsHandler : IRequestHandler<SetPostTagsCommand, Result<bool>>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;

    public SetPostTagsHandler(IPostRepository postRepository, ITagRepository tagRepository)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
    }

    public async Task<Result<bool>> Handle(SetPostTagsCommand request, CancellationToken cancellationToken)
    {
        var validPost = await _postRepository.GetByIdAsync(request.PostId);
        if (validPost == null)
        {
            var error = new PostNotFoundException($"Post with id: {request.PostId} was not found");
            return new Result<bool>(error);
        }

        var validTags = await _tagRepository.GetTagsByIdsAsync(request.TagIds);


        await _postRepository.SetTagsAsync(request.PostId, validTags);

        return new Result<bool>(true);
    }
}