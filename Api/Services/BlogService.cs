using Microsoft.Extensions.Logging;
using Primitives.Blogs;

namespace Taka.blogs.Services
{
    public class BlogService : IBlogService
    {
        private readonly IEnumerable<string> names = new List<string>() { "taka", "nao" };
        private readonly ILogger<BlogService> logger;
        public BlogService(ILogger<BlogService> logger)
        {
            this.logger = logger;
        }

        public IEnumerable<string> ListBlogs()
        {
            return names;            
        }

        public int Sample()
        {
            this.logger.ToString();
            int count = 0;
            return count;
        }

        public async Task<bool> IsValidAsync(
            string text,
            string? type,
            CancellationToken cancellationToken
        )
        {
            return true;
        }

        public async Task<bool> PublishAsync(
            string text,
            CancellationToken cancellation
        )
        {
            return true;
        }
    }
}