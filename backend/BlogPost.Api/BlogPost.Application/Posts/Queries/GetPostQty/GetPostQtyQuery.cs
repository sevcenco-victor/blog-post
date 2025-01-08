using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostQty;

public record GetPostQtyQuery() : IRequest<Result<int>>; 
