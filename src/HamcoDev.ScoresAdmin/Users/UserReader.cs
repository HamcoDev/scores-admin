namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;
    using System.Net;

    public class UserReader : IUserReader
    {
        public List<string> GetUserIds()
        {
            var userIds = new List<string>();

            var url = string.Format("http://ionic-scores.firebaseio.com/users.json");
            
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                var idArray = json.Split(new[] { "email" }, System.StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < idArray.Length; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    var userEntry = idArray[i];

                    userIds.Add(userEntry.Substring(userEntry.IndexOf("id") + 5, 36));
                }
            }

            return userIds;
        }
    }
}