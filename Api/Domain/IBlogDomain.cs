using Blog.Primitives;

namespace Blog.Domain
{
    public interface IBlogDomain
    {
        IEnumerable<BlogRecord> list();
        IEnumerable<BlogRecord> get(string id);
    }

}
