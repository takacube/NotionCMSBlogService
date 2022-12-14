using Blog.Primitives;

namespace Blog.Domain
{
    public interface IBlogDomain
    {
        IEnumerable<BlogMainRecord> list();
        BlogRecord get(string id);
        IEnumerable<BlogRecord> fullList();
        string toUrl(string content);
    }

}
