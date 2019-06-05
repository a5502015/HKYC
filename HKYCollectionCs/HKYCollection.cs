using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HKYCollectionCs
{
    class HKYCollection
    {
        private  string[] keyWords = { "韓國瑜","韓流" };
        private string[] source = { "https://tw.news.yahoo.com/search?p=" };
        private List<NewsItem> newsList = new List<NewsItem>();

        public async void search()
        {
            foreach(var web in source)
            {
                foreach(var key in keyWords)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(web+key);
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Above three lines can be replaced with new helper method below
                        // string responseBody = await client.GetStringAsync(uri);

                        Console.WriteLine(responseBody);

                        using(StreamWriter sw = new StreamWriter(@".\news.html"))
                        {
                            sw.WriteLine(responseBody);
                        }
                    }
                }
            }
        }
        public void cutHtml(string source)
        {
            NewsItem ni = new NewsItem();
            if(new Regex("yahoo").IsMatch(source))
            {
                //Yahoo格式
                string urlHead = @"https://tw.news.yahoo.com";
            }

        }
    }

    class NewsItem
    {
        public string url { get; set; }
        public string picUrl { get; set; }
        public string titles { get; set; }
        public string hashTag { get; set; }
    }
}
