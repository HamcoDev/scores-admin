namespace HamcoDev.ScoresAdmin.Results
{
    using System.Net;

    using Newtonsoft.Json;

    public class ResultsProcessor : IResultsProcessor
    {
        public void Process()
        {
            // download results data
            var url = "http://api.football-data.org/alpha/soccerseasons/398/fixtures?matchday=7";
            using (var wc = new WebClient())
            {
                var json = wc.DownloadString(url);

                var js = JsonConvert.DeserializeObject<RootObject>(json); 
            }
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