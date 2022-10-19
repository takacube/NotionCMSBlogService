using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taka.blogs.Services
{
    public interface IBlogService
    {
        IEnumerable<string> ListBlogs();
        int Sample();

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
