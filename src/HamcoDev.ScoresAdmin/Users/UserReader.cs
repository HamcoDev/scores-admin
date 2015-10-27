namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;
    using System.Net;

    using Newtonsoft.Json;

    public class UserReader : IUserReader
    {
        public List<User> GetUserIds()
        {
            var users = new List<User>();

            var url = string.Format("http://ionic-scores.firebaseio.com/user.json");

            User resultJson;

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                resultJson = JsonConvert.DeserializeObject<User>(json);
            }

            return null;
        }
    }
}