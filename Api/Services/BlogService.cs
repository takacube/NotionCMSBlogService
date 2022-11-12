using Microsoft.Extensions.Logging;
using Blog.Primitives;
using Blog.Domain;
namespace Blog.Services
{
    public class BlogService : IBlogService
    {
        private readonly ILogger<BlogService> logger;
        private readonly IBlogDomain blogDomain;
        public BlogService(ILogger<BlogService> logger, IBlogDomain blogDomain)
        {
            this.logger = logger;
            this.blogDomain = blogDomain;
        }

        public IEnumerable<BlogMainRecord> ListBlogs()
        {
            var blogList = this.blogDomain.list();
            foreach (var blog in blogList)
            {
                yield return blog;
            }            
        }

        public IEnumerable<BlogRecord> ListBlogsFullData()
        {
            var blogList = this.blogDomain.fullList();
            foreach (var blog in blogList)
            {
                yield return blog;
            }
        }
        public BlogRecord GetBlog(string id)
        {
            return this.blogDomain.get(id);
        }

        public async Task<bool> IsValidAsync(
            string text,
            string? type,
            CancellationToken cancellationToken
        )
        {
            await Task.WhenAll();
            return true;
        }

        public async Task<bool> PublishAsync(
            string text,
            CancellationToken cancellation
        )
        {
            await Task.WhenAll();
            return true;
        }
    }
}