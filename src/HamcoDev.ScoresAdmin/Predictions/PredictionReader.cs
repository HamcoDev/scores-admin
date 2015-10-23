namespace HamcoDev.ScoresAdmin.Predictions
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    using Newtonsoft.Json;

    public class PredictionReader : IPredictionReader
    {
        public List<FixtureResult> GetPredictions(string userId, int matchday)
        {
            var predictions = new List<FixtureResult>();

            var url = string.Format("http://ionic-scores.firebaseio.com/scores/user/{0}/matchday/{1}.json", userId, matchday);

            RootObject resultJson;

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                resultJson = JsonConvert.DeserializeObject<RootObject>(json);
            }

            foreach (var fixture in resultJson.fixture)
            {
                predictions.Add(
                    new FixtureResult
                    {
                        Date = DateTime.Parse(fixture.date),
                        HomeTeam = fixture.homeTeam,
                        AwayTeam = fixture.awayTeam,
                        Score = new Score
                        {
                            Home = fixture.homePrediction,
                            Away = fixture.awayPrediction
                        }
                    });

            }

            return predictions;
        }
    }
}
