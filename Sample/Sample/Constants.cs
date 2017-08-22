namespace Sample
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = "http://www.twoyellowbirds.in/wp-json/wp/v2/posts?page={0}&per_page={1}";
        public static string ImageUrl = "http://www.twoyellowbirds.in/wp-json/wp/v2/media/{0}";
        // Credentials that are hard coded into the REST service
        public static string Username = "Xamarin";
        public static string Password = "Pa$$w0rd";
        public static string PostCount = "10";
    }
}
