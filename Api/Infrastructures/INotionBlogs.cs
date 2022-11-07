using Blog.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructures
{
    public interface INotionBlogs
    {
        IEnumerable<BlogMainRecord> FindAllAsync();
        BlogRecord FindById(string id);
    }
}
