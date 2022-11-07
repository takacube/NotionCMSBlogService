using Blog.Primitives;

namespace Blog.Domain
{
    public interface IBlogDomain
    {
        IEnumerable<BlogMainRecord> list();
        BlogRecord get(string id);
    }

}
