namespace Blog.Primitives
{
    public record CheckBlogParameters(
        string Text,
        string UserId,
        string? Type
    );

    public record BlogRecord(
        string Content,
        string Title,
        string Header,
        string Id
    );
}