namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;

    public class UserReader : IUserReader
    {
        public List<string> GetUserIds()
        {
            var predictions = new List<string>();

            var url = string.Format("http://ionic-scores.firebaseio.com/user.json");

            RootObject resultJson;

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                resultJson = JsonConvert.DeserializeObject<RootObject>(json);
            }

            return null;
        }
    }
}