namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;
    using System.Linq;

    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Predictions;
    using HamcoDev.ScoresAdmin.Scores;
    using HamcoDev.ScoresAdmin.Users;

    public class ResultsPopulator
    {
        private readonly int matchday;

        public ResultsPopulator(int matchday)
        {
            this.matchday = matchday;
        }

        public void Run()
        {
            // get results from api
            var fixtureReader = new FixtureReader();
            var actualResults = fixtureReader.GetResults(this.matchday);

            var predicationsReader = new PredictionReader();

            var userReader = new UserReader();
            var userIds = userReader.GetUserIds();

            foreach (var userId in userIds)
            {
                var predictedResults = predicationsReader.GetPredictions(userId, this.matchday);

                var totalScore = 0;

                if (predictedResults.Any())
                {
                    var scoresCalculator = new ScoresCalculator();
                    totalScore = scoresCalculator.Calculate(predictedResults, actualResults);
                }

                // write results to the Firebase
                var scoresWriter = new ScoresWriter();
                scoresWriter.WriteScores(userId, this.matchday, totalScore);
            }
        }
    }
}