﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Primitives.Blogs;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Taka.blogs.Services;

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
        public IEnumerable<string> Get()
        {
            IEnumerable<string> list = new List<string>() { "taro", "yoshi" };
            var blogService = this.BlogService;
            IEnumerable<string> nameList = blogService.ListBlogs();
            foreach (string name in nameList)
            { 
                Console.WriteLine(name);
                yield return name;
            }
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
