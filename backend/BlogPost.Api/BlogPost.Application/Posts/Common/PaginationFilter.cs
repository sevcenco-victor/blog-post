namespace BlogPost.Application.Posts.Common;

public record PaginationFilter(int PageNumber, int PageSize, string? Title, Guid[]? TagIds);