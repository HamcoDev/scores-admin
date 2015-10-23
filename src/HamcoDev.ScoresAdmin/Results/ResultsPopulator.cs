namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;

    public class ResultsPopulator
    {
        public void Run()
        {
            // get results from api
            var fixtureReader = new FixtureReader();
            var actualResults = fixtureReader.GetResults();

            // get predictions for user from The Firebase
            var predicationsReader = new PredictionReader();
            var predictedResults = predicationsReader.GetPredictions("6098c704-b809-4722-add2-3caf30a44a13", 10);

            // call ScoresCalculator
            var scoresCalculator = new ScoresCalculator();
            var totalScore = scoresCalculator.Calculate(predictedResults, actualResults);

            // write results to the Firebase
        }
    }
}