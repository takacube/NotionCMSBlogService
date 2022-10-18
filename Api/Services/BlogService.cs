namespace Taka.blogs.Services
{
    public class BlogService
    {
        private readonly IEnumerable<string> _names;
        public BlogService(IEnumerable<string> names)
        {
            _names = names;
        }

        public IEnumerable<string> ListBlogs()
        {
            return _names;            
        }
    }
}