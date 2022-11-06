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
        public IEnumerable<BlogRecord> ListBlogs()
        {
            IEnumerable<BlogRecord> nameList = this.BlogService.ListBlogs();
            foreach (BlogRecord name in nameList)
            { 
                Console.WriteLine(name);
                yield return name;
            }
        }

        [HttpGet]
        [Route("get")]

        public IEnumerable<BlogRecord> GetBlog(string id)
        {
            IEnumerable<BlogRecord> blog = this.BlogService.GetBlog(id);
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
