using System;

namespace Sample
{
    public class ImageItem
    {
        public int id { get; set; }

        public string date { get; set; }

        public string date_gmt { get; set; }

        public object guid { get; set; }
        public string modified { get; set; }
        public string modified_gmt { get; set; }
        public string slug { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public object title { get; set; }
        public int author { get; set; }
        public int featured_media { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string template { get; set; }
        public object meta { get; set; }
        public object description { get; set; }
        public object caption { get; set; }
        public string alt_text { get; set; }
        public string media_type { get; set; }
        public string mime_type { get; set; }
        public object media_details { get; set; }
        public int post { get; set; }
        public string source_url { get; set; }
        public object _links { get; set; }
    }
}
