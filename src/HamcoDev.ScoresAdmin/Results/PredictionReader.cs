using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace HamcoDev.ScoresAdmin.Results
{
    public class PredictionReader : IPredictionReader
    {
        public List<FixtureResult> GetPredictions(string userId, int matchday)
        {
            var predictions = new List<FixtureResult>();

            var url = string.Format("http://ionic-scores.firebaseio.com/scores/user/{0}/matchday/{1}.json", userId, matchday);

            PredictionList resultJson;

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                resultJson = JsonConvert.DeserializeObject<PredictionList>(json);
            }

            foreach (var fixture in resultJson.fixtures)
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
