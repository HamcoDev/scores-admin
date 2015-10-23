namespace HamcoDev.ScoresAdmin.Scores
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Results;

    public class ScoresCalculator : IScoresCalculator
    {
        private readonly IResultsProcessor resultsProcessor;

        public ScoresCalculator(IResultsProcessor resultsProcessor)
        {
            this.resultsProcessor = resultsProcessor;
        }

        public ScoresCalculator()
        {
            this.resultsProcessor = new ResultsProcessor();
        }

        public int Calculate(List<FixtureResult> predictedResults, List<FixtureResult> actualResults)
        {
            var total = 0;

            foreach (var actualResult in actualResults)
            {
                var predictedResult = predictedResults
                    .Where(p => p.HomeTeam == actualResult.HomeTeam)
                    .Where(p => p.AwayTeam == actualResult.AwayTeam)
                    .SingleOrDefault(p => p.Date == actualResult.Date);

                if (predictedResult == null)
                {
                    throw new Exception("Invalid data");
                }

                total += this.resultsProcessor.CheckScore(predictedResult.Score, actualResult.Score);
            }

            return total;
        }
    }
}