namespace BlogPost.Application.Contracts.Post;

public record PaginationFilter(int PageNumber, int PageSize, string? Title, int[]? TagIds);