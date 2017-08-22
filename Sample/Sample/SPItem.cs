using System;

namespace Sample
{
    public class SPItem
    {
        public int id { get; set; }

        public string date { get; set; }

        public string date_gmt { get; set; }

        public GUID guid { get; set; }
        public string modified { get; set; }
        public string modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public Title title { get; set; }
        public Content content { get; set; }
        public object excerpt { get; set; }
        public int author { get; set; }
        public int featured_media { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public bool sticky { get; set; }
        public string template { get; set; }
        public string format { get; set; }
        public object meta { get; set; }
        public object categories { get; set; }
        public object tags { get; set; }
        public object _links { get; set; }
    }
    public class GUID
    {
        public string rendered { get; set; }
    }
    public class Title
    {
        public string rendered { get; set; }
    }
    public class Content
    {
        public string rendered { get; set; }
        public bool Isprotected { get; set; }
    }
}
