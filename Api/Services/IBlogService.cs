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
    }
}
