namespace HamcoDev.ScoresAdmin.Results
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HamcoDev.ScoresAdmin.Common;
    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Predictions;
    using HamcoDev.ScoresAdmin.Scores;
    using HamcoDev.ScoresAdmin.Users;

    using Newtonsoft.Json;

    public class ResultsPopulator
    {
        private readonly IFirebase firebase;

        private int matchday;

        public ResultsPopulator()
        {
            this.firebase = new Firebase();
        }

        public void Run()
        {
            this.matchday = this.firebase.ReadInt("/currentMatchday.json");
            Console.WriteLine($"Processing matchday {this.matchday}");
            
            var fixtureReader = new FixtureReader();
            var actualResults = fixtureReader.GetResults(this.matchday);

            var predicationsReader = new PredictionReader();

            var userReader = new UserReader();
            var userIds = userReader.GetUserIds();

            this.WriteUserWeeklyScore(userIds, predicationsReader, actualResults);
        }

        private void WriteUserWeeklyScore(IEnumerable<string> userIds, IPredictionReader predicationsReader, List<FixtureResult> actualResults)
        {
            foreach (var userId in userIds)
            {
                Console.WriteLine($"Processing user {userId}");
                var predictedResults = predicationsReader.GetPredictions(userId, this.matchday);

                var matchdayTotal = 0;

                if (predictedResults.Any())
                {
                    var scoresCalculator = new ScoresCalculator();
                    matchdayTotal = scoresCalculator.Calculate(predictedResults, actualResults);
                }

                Console.WriteLine($"Weekly score: {matchdayTotal}");
                this.firebase.Write($"/scores/user/{userId}/matchday/{this.matchday}/points.json", matchdayTotal.ToString());

                this.WriteUserTotalScore(userId);
            }
        }

        private void WriteUserTotalScore(string userId)
        {
            var totalScore = 0;

            for (var i = 1; i <= this.matchday; i++)
            {
                var json = this.firebase.Read($"/scores/user/{userId}/matchday/{i}/points.json");

                if (json != "null")
                {
                    totalScore += JsonConvert.DeserializeObject<int>(json);
                }
            }

            Console.WriteLine($"Total score: {totalScore}");
            this.firebase.Write($"/scores/user/{userId}/totalPoints.json", totalScore.ToString());
        }
    }
}