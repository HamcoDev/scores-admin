namespace HamcoDev.ScoresAdmin.Results
{
    public class ResultsProcessor : IResultsProcessor
    {
        public int CheckScore(Score predictedScore, Score actualScore)
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