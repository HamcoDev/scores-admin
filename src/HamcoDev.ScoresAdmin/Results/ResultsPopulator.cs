namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;

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
            var users = userReader.GetUserIds();

            foreach (var user in users)
            {
                var predictedResults = predicationsReader.GetPredictions(user, this.matchday);

                // call ScoresCalculator
                var scoresCalculator = new ScoresCalculator();
                var totalScore = scoresCalculator.Calculate(predictedResults, actualResults);

                // write results to the Firebase
                var scoresWriter = new ScoresWriter();
                scoresWriter.WriteScores(user, this.matchday, totalScore);
            }
        }
    }
}