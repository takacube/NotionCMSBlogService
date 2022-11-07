namespace Primitives.Blogs
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NotionPageAnnotations
    {
        public bool bold { get; set; }
        public bool italic { get; set; }
        public bool strikethrough { get; set; }
        public bool underline { get; set; }
        public bool code { get; set; }
        public string color { get; set; }
    }

    public class NotionPageCreatedBy
    {
        public string @object { get; set; }
        public string id { get; set; }
    }

    public class NotionPageIcon
    {
        public string type { get; set; }
        public string emoji { get; set; }
    }

    public class NotionPageLastEditedBy
    {
        public string @object { get; set; }
        public string id { get; set; }
    }

    public class NotionPageParent
    {
        public string type { get; set; }
        public string page_id { get; set; }
    }

    public class NotionPageProperties
    {
        public NotionPageTitle title { get; set; }
    }

    public class NotionPage
    {
        public string @object { get; set; }
        public string id { get; set; }
        public DateTime created_time { get; set; }
        public DateTime last_edited_time { get; set; }
        public NotionPageCreatedBy created_by { get; set; }
        public NotionPageLastEditedBy last_edited_by { get; set; }
        public object cover { get; set; }
        public NotionPageIcon icon { get; set; }
        public NotionPageParent parent { get; set; }
        public bool archived { get; set; }
        public NotionPageProperties properties { get; set; }
        public string url { get; set; }
    }

    public class NotionPageText
    {
        public string content { get; set; }
        public object link { get; set; }
    }

    public class NotionPageTitle
    {
        public string id { get; set; }
        public string type { get; set; }
        public List<NotionPageTitle> title { get; set; }
        public NotionPageText text { get; set; }
        public NotionPageAnnotations annotations { get; set; }
        public string plain_text { get; set; }
        public object href { get; set; }
    }

    public record TitleAndIcon
    (
        string emoji, 
        string title
    );
}
