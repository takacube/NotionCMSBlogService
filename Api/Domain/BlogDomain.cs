using Blog.Primitives;
using System.Reflection.PortableExecutable;

namespace Blog.Domain
{
    public class BlogDomain: IBlogDomain
    {
        public BlogDomain() { 
        }

        public IEnumerable<BlogRecord> list() {
            var blogs = new List<BlogRecord>() { new BlogRecord("Content1", "Title1", "Header1", "Id1"), new BlogRecord("Content2", "Title2", "Header2", "Id2") };
            foreach (var record in blogs) { 
                yield return record;
            }
        }

        public IEnumerable<BlogRecord> get(string id) {
            yield return new BlogRecord("Content1", "Title1", "Header1", "Id1");
        }
    }
}