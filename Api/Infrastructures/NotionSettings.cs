namespace Blog.Infrastructures;
public record NotionSettings(
    string PageUrl,
    string BlockVhildUrl,
    string BlockUrl, 
    string Authorization,
    string NotionVersion)
{
    public NotionSettings() : this(
        PageUrl: string.Empty,
        BlockVhildUrl: string.Empty,
        BlockUrl: string.Empty,
        Authorization: string.Empty,
        NotionVersion: string.Empty)
    { }
}
