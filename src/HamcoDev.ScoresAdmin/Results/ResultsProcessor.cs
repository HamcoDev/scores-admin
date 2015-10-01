namespace HamcoDev.ScoresAdmin.Results
{

    public class ResultsProcessor : IResultsProcessor
    {
        private readonly IFixtureReader fixtureReader;

        public ResultsProcessor()
        {
            this.fixtureReader = new FixtureReader();
        }

        public ResultsProcessor(IFixtureReader fixtureReader)
        {
            this.fixtureReader = fixtureReader;
        }

        public void Process()
        {
            // download results data
            var results = this.fixtureReader.GetResults();
        }

        public int CheckScore(Score actualScore, Score predictedScore)
        {
            if (actualScore.Home == predictedScore.Home && actualScore.Away == predictedScore.Away)
            {
                return 3;
            }
            
            if (this.CheckResult(actualScore) == this.CheckResult(predictedScore))
            {
                return 1;
            }

            return 0;
        }

        private Result CheckResult(Score score)
        {
            if (score.Home > score.Away)
            {
                return Result.HomeWin;
            }
            if (score.Home < score.Away)
            {
                return Result.AwayWin;
            }

            return Result.Draw;
        }
    }
}