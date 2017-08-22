using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Collections.ObjectModel;

namespace Sample
{
    public class RestService : IRestService
    {
        HttpClient client;
        HtmlDocument htmlDoc;
        public List<SPItem> SPItems { get; private set; }
        private static ObservableCollection<YBItem> Items { get; set; }
        public RestService()
        {
            client = new HttpClient();
            htmlDoc = new HtmlDocument();

            var authData = string.Format("{0}:{1}", Constants.Username, Constants.Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task<ObservableCollection<YBItem>> RefreshDataAsync(int pageCount)
        {
            SPItems = new List<SPItem>();
            Items = new ObservableCollection<YBItem>();
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
            var uri = new Uri(string.Format(Constants.RestUrl, pageCount, Constants.PostCount));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Regex.Replace(content, @"\bprotected", "Isprotected");
                    SPItems = JsonConvert.DeserializeObject<List<SPItem>>(content);
                    
                    foreach (var item in SPItems)
                    {
                        htmlDoc.LoadHtml(item.content.rendered);
                        item.content.rendered = htmlDoc.DocumentNode.Element("p").InnerText;
                        ImageItem imageItem = new ImageItem();
                        uri = new Uri(string.Format(Constants.ImageUrl, item.featured_media));
                        response = await client.GetAsync(uri);
                        if (response.IsSuccessStatusCode)
                        {
                            content = await response.Content.ReadAsStringAsync();
                            imageItem = JsonConvert.DeserializeObject<ImageItem>(content);
                        }
                        Items.Add(new YBItem() { ImageURL = imageItem.source_url, LogLine = item.content.rendered, Title = item.title.rendered, LinkURL = item.link });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return Items;
        }
    }
}
