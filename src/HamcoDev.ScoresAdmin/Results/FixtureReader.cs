namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;
    using System.Net;
    using System.Runtime.Remoting.Messaging;

    using Newtonsoft.Json;

    public class FixtureReader : IFixtureReader
    {
        public List<FixtureResult> GetResults()
        {
            var results = new List<FixtureResult>();
            var url = "http://api.football-data.org/alpha/soccerseasons/398/fixtures?matchday=7";

            RootObject resultJson;

            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                resultJson = JsonConvert.DeserializeObject<RootObject>(json);
            }

            foreach (var fixture in resultJson.fixtures)
            {
                results.Add(
                    new FixtureResult
                    {
                        Date = fixture.date,
                        HomeTeam = fixture.homeTeamName,
                        AwayTeam = fixture.awayTeamName,
                        Score = new Score
                        {
                            Home = fixture.result.goalsHomeTeam,
                            Away = fixture.result.goalsAwayTeam
                        }
                    });

            }

            return results;
        }
    }
}