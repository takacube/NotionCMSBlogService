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
            blog.Content.Replace(blog.Content, $"<a href=\"{blog.Content}\">{blog.Content}</a>");
            return blog;
        }

        public IEnumerable<BlogRecord> fullList() {
            var blogs = this.notionBlogs.FindAllAsync();
            foreach (var record in blogs) {
                var blogFullInofo = this.get(record.Id);
                yield return blogFullInofo;
            }
        }

        public string toUrl(string content) {
            return content;        
        }
    }
}