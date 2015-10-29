namespace HamcoDev.ScoresAdmin.Users
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    [JsonObject]
    public class User
    {
        public string id { get; set; }

        public string name { get; set; }

        public string email { get; set; }
    }

    public class User1
    {
        public List<User> user { get; set; }
    }
}