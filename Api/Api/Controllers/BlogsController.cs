using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taka.blogs.Services;

namespace Taka.blogs
{
    [Route("[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public  IEnumerable<string> Get()
        {
            IEnumerable<string> list = new List<string>() { "taro", "yoshi" };
            var blogService = new BlogService(list);
            IEnumerable<string> nameList = blogService.ListBlogs();
            foreach (string name in nameList)
            { 
                Console.WriteLine(name);
                yield return name;
            }
        }
    }
}
