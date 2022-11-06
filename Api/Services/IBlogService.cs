using Blog.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Services
{
    public interface IBlogService
    {
        IEnumerable<BlogRecord> ListBlogs();
        IEnumerable<BlogRecord> GetBlog(string id);
        Task<bool> IsValidAsync(
            string text,
            string? type,
            CancellationToken cancellationToken
        );

        Task<bool> PublishAsync(
            string text,
            CancellationToken cancellationToken
        );
    }
}
