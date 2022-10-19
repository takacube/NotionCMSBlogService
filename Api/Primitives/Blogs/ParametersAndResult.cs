namespace Primitives.Blogs
{
    public record CheckBlogParameters(
        string Text,
        string UserId,
        string? Type
    );
}