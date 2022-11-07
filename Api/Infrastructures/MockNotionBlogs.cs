using Blog.Infrastructures;
using Blog.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures
{
    public class MockNotionBlogs : INotionBlogs
    {

        public MockNotionBlogs() { }
        public IEnumerable<BlogMainRecord> FindAllAsync()
        {
            //var client = new HttpClient();
            //var res = await client.GetAsync("https://weather.tsukumijima.net/api/forecast/city/400040");
            var blogs = new List<BlogMainRecord>() { new BlogMainRecord("Content1", "Title1"), new BlogMainRecord("Content2", "Id2") };
            foreach (var blog in blogs)
            { 
                yield return blog;
            }
        }

        public BlogRecord FindById(string id)
        {
            //var client = new HttpClient();
            //var res = await client.GetAsync("https://weather.tsukumijima.net/api/forecast/city/400040");
            var blogs = new BlogRecord("Content1", "Title1", "Header1", "Id1");
            return blogs;
        }
    }
}
