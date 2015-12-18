namespace HamcoDev.ScoresAdmin.Predictions
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using HamcoDev.ScoresAdmin.Common;
    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    using Newtonsoft.Json;

    public class PredictionReader : IPredictionReader
    {
        private readonly IFirebase firebase;

        public PredictionReader()
        {
            this.firebase = new Firebase();
        }

        public List<FixtureResult> GetPredictions(string userId, int matchday)
        {
            var predictions = new List<FixtureResult>();

            var url = $"/scores/user/{userId}/matchday/{matchday}.json";

            var json = this.firebase.Read(url);

            var resultJson = JsonConvert.DeserializeObject<RootObject>(json);

            if (resultJson != null && resultJson.fixture != null)
            {
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
            }

            return predictions;
        }
    }
}
