using BlogPost.Application.Contracts.Post;
using FluentValidation;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public sealed class CreatePostValidator : AbstractValidator<CreatePostRequest>
{
    public CreatePostValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(5, 50)
            .WithMessage("Title must be between 5 and 50 characters");

        RuleFor(x => x.Text)
            .NotEmpty()
            .MinimumLength(5)
            .WithMessage("Text must have at least 5 characters");

        RuleFor(x => x.ImageUrl)
            .NotEmpty()
            .WithMessage("ImageUrl must be provided");

        RuleFor(x => x.TagIds)
            .NotEmpty()
            .WithMessage("Post must have at least one tag");

        RuleFor(x => x.MarkdownFileContent)
            .NotEmpty()
            .WithMessage("MarkdownFileContent must not be empty");
    }
}