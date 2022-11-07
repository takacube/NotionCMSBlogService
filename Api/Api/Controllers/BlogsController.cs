using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Primitives;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Blog.Services;

namespace Taka.blogs
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        public BlogsController(IBlogService blogService)
        { 
            this.BlogService = blogService;
        }
        [HttpGet]
        [Route("list")]
        public IEnumerable<BlogMainRecord> ListBlogs()
        {
            IEnumerable<BlogMainRecord> nameList = this.BlogService.ListBlogs();
            foreach (BlogMainRecord name in nameList)
            { 
                Console.WriteLine(name);
                yield return name;
            }
        }

        [HttpGet]
        [Route("get")]

        public BlogRecord GetBlog(string id)
        {
            BlogRecord blog = this.BlogService.GetBlog(id);
            return blog;
        }

        [HttpPost]
        [Route("publish")]

        public bool Publish(
            [FromBody, Required] CheckBlogParameters parameters,
            CancellationToken cancellationToken
            )
        {
            return true;
        }
        private IBlogService BlogService { get; set; }
    }
}
