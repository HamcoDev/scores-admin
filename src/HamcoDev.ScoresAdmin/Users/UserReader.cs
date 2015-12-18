namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;
    using System.Net;

    using HamcoDev.ScoresAdmin.Common;

    public class UserReader : IUserReader
    {
        private readonly IFirebase firebase;

        public UserReader()
        {
            this.firebase = new Firebase();
        }

        public List<string> GetUserIds()
        {
            var userIds = new List<string>();

            var url = "/users.json";

            var json = this.firebase.Read(url);

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

            return userIds;
        }
    }
}