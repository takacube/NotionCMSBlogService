using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Primitives
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class NotionBlockChildAnnotations
    {
        public bool bold { get; set; }
        public bool italic { get; set; }
        public bool strikethrough { get; set; }
        public bool underline { get; set; }
        public bool code { get; set; }
        public string color { get; set; }
    }

    public class NotionBlockChildBlock
    {
    }

    public class NotionBlockChildCode
    {
        public List<object> caption { get; set; }
        public List<NotionBlockChildRichText> rich_text { get; set; }
        public string language { get; set; }
    }

    public class NotionBlockChildCreatedBy
    {
        public string @object { get; set; }
        public string id { get; set; }
    }

    public class NotionBlockChildLastEditedBy
    {
        public string @object { get; set; }
        public string id { get; set; }
    }

    public class NotionBlockChildParagraph
    {
        public List<NotionBlockChildRichText> rich_text { get; set; }
        public string color { get; set; }
    }

    public class NotionBlockChildParent
    {
        public string type { get; set; }
        public string page_id { get; set; }
    }


    public class NotionBlockChildChildPage
    {
        public string title { get; set; }
    }
    public class NotionBlockChildResult
    {
        public string @object { get; set; }
        public string id { get; set; }
        public NotionBlockChildParent parent { get; set; }
        public DateTime created_time { get; set; }
        public DateTime last_edited_time { get; set; }
        public NotionBlockChildCreatedBy created_by { get; set; }
        public NotionBlockChildLastEditedBy last_edited_by { get; set; }
        public bool has_children { get; set; }

        public NotionBlockChildChildPage child_page { get; set; }
    public bool archived { get; set; }
        public string type { get; set; }
        public NotionBlockChildParagraph paragraph { get; set; }
        public NotionBlockChildCode code { get; set; }
    }

    public class NotionBlockChildRichText
    {
        public string type { get; set; }
        public NotionBlockChildText text { get; set; }
        public NotionBlockChildAnnotations annotations { get; set; }
        public string plain_text { get; set; }
        public object href { get; set; }
    }

    public class NotionBlockChild
    {
        public string @object { get; set; }
        public List<NotionBlockChildResult> results { get; set; }
        public object next_cursor { get; set; }
        public bool has_more { get; set; }
        public string type { get; set; }
        public NotionBlockChildBlock block { get; set; }
    }

    public class NotionBlockChildText
    {
        public string content { get; set; }
        public object link { get; set; }
    }

}
