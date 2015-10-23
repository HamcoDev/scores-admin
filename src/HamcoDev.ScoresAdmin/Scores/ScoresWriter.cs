namespace HamcoDev.ScoresAdmin.Scores
{
    using System;
    using System.Net;

    using Newtonsoft.Json;

    public class ScoresWriter : IScoresWriter
    {
        public string WriteScores(string userId, int matchday, int points)
        {
            var url = string.Format(
                "https://ionic-scores.firebaseio.com/scores/user/{0}/matchday/{1}/points.json",
                userId,
                matchday);

            var address = new Uri(url);

            const string Method = "PUT";
            var client = new WebClient();

            var jsonString = JsonConvert.SerializeObject(
                new
                {
                    points = points.ToString()
                });

            var response = client.UploadString(address, Method, points.ToString());

            return response;
        }
    }
}