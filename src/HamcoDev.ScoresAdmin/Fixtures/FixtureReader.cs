namespace HamcoDev.ScoresAdmin.Fixtures
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    using Newtonsoft.Json;

    public class FixtureReader : IFixtureReader
    {
        public List<FixtureResult> GetResults(int matchday)
        {
            var results = new List<FixtureResult>();
            var url = $"http://api.football-data.org/alpha/soccerseasons/398/fixtures?matchday={matchday}";

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
                        Date = DateTime.Parse(fixture.date),
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