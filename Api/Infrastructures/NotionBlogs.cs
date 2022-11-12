using Blog.Primitives;
using Infrastructures;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Primitives.Blogs;
using System.Net;

namespace Blog.Infrastructures
{
    public class NotionBlogs : INotionBlogs
    {
        private IOptions<NotionSettings> NotionSettings { get; }
        public NotionBlogs(IOptions<NotionSettings> NotionSettings) {
            this.NotionSettings = NotionSettings;
        }
        public IEnumerable<BlogMainRecord> FindAllAsync()
        {
            var client = new HttpClient();
            var request = NotionConn(this.NotionSettings.Value.BlockUrl);
            HttpStatusCode resStatusCode = HttpStatusCode.NotFound;
            Task<HttpResponseMessage> response;
            List<NotionBlockChildResult>? results = new List<NotionBlockChildResult>() { };
            try
            {
                response = client.SendAsync(request);
                var resBody = response.Result.Content.ReadAsStringAsync().Result;
                resStatusCode = response.Result.StatusCode;

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                
                var deserializedBody = JsonConvert.DeserializeObject<NotionBlockChild>(resBody);
                Console.WriteLine(deserializedBody);
                results = (deserializedBody is not null) ? deserializedBody.results : results;
            }
            catch (Exception err) {
                throw new Exception($"[Error] unexpected error has occured : {err}");
            }
            if (!resStatusCode.Equals(HttpStatusCode.OK))
            {
                throw new Exception($"statuc code is not 200 {resStatusCode}");
            }
            //blogs = new List<BlogRecord>() { new BlogRecord("Content1", "Title1", "Header1", "Id1"), new BlogRecord("Content2", "Title2", "Header2", "Id2") };
            
            foreach (var result in results)
            {
                Console.WriteLine(result);
                if (result.child_page is null) {
                    continue;
                }
                var title = result.child_page.title;
                var id = result.id;

                var res = new BlogMainRecord(title, id);
                yield return res;
            }
            
        }

        public BlogRecord FindById(string id)
        {
            var client = new HttpClient();
            var request = NotionConn("https://api.notion.com/v1/blocks/" + id + "/children?page_size=100");
            HttpStatusCode resStatusCode = HttpStatusCode.NotFound;
            Task<HttpResponseMessage> response;
            List<NotionBlockChildResult>? results = new List<NotionBlockChildResult>() { };
            try
            {
                response = client.SendAsync(request);
                var resBody = response.Result.Content.ReadAsStringAsync().Result;
                resStatusCode = response.Result.StatusCode;

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                var deserializedBody = JsonConvert.DeserializeObject<NotionBlockChild>(resBody);

                results = (deserializedBody is not null) ? deserializedBody.results : results;
            }
            catch (Exception err)
            {
                throw new Exception($"[Error] unexpected error has occured : {err}");
            }
            if (!resStatusCode.Equals(HttpStatusCode.OK))
            {
                throw new Exception($"statuc code is not 200 but: {resStatusCode}");
            }
       
            var blogText = string.Join("", results.Select(result => {
                if (result is not null)
                {
                    return (result.type == "paragraph" && result.paragraph.rich_text.Count() != 0) ? result.paragraph.rich_text[0].text.content: "";
                }
                else {
                    return "";
                }
            }).ToArray());
            var pageMainContent = GetPageInfo(id);
            return new BlogRecord(blogText, pageMainContent.title, pageMainContent.emoji, id);
        }

        private HttpRequestMessage NotionConn(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Notion-Version", this.NotionSettings.Value.NotionVersion);
            request.Headers.Add("Authorization", this.NotionSettings.Value.Authorization); ;
            return request;
        }

        private TitleAndIcon GetPageInfo(string id)
        {
            var client = new HttpClient();
            var request = NotionConn("https://api.notion.com/v1/pages/" + id);
            HttpStatusCode resStatusCode = HttpStatusCode.NotFound;
            Task<HttpResponseMessage> response;
            try
            {
                response = client.SendAsync(request);
                var resBody = response.Result.Content.ReadAsStringAsync().Result;
                resStatusCode = response.Result.StatusCode;

                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                var deserializedBody = JsonConvert.DeserializeObject<NotionPage>(resBody);

                var emoji = (deserializedBody.icon is not null) ? deserializedBody.icon.emoji : "🤣" ;
                var title = deserializedBody.properties.title.title[0].text.content;
                return new TitleAndIcon(emoji, title);
            }
            catch (Exception err)
            {
                throw new Exception($"[Error] unexpected error has occured : {err}");
            }
        }
    }
}