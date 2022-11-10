using Blog.Infrastructures;
using Blog.Primitives;
using System.Reflection.PortableExecutable;

namespace Blog.Domain
{
    public class BlogDomain: IBlogDomain
    {
        private readonly INotionBlogs notionBlogs;
        public BlogDomain(INotionBlogs notionBlogs) { 
            this.notionBlogs = notionBlogs;
        }

        public IEnumerable<BlogMainRecord> list() {
            var blogs = this.notionBlogs.FindAllAsync();
            foreach (var record in blogs) { 
                yield return record;
            }
        }
        public BlogRecord get(string id) {
            var blog = this.notionBlogs.FindById(id);
            return blog;
        }
    }
}