namespace HamcoDev.ScoresAdmin.Common
{
    using System;
    using System.Net;

    using Newtonsoft.Json;

    public class Firebase : IFirebase
    {
        private const string BaseUrl = "https://ionic-scores.firebaseio.com";

        public string Read(string url)
        {
            url = $"{BaseUrl}{url}";

            string json;

            using (var wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }

            return json;
        }

        public int ReadInt(string url)
        {
            var json = this.Read(url);
            return JsonConvert.DeserializeObject<int>(json);
        }

        public string Write(string url, string data)
        {
            url = $"{BaseUrl}{url}";

            var address = new Uri(url);

            const string Method = "PUT";
            var client = new WebClient();
            var response = client.UploadString(address, Method, data);

            return response;
        }
    }
}