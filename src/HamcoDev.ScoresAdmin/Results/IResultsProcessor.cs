namespace HamcoDev.ScoresAdmin.Results
{
    public interface IResultsProcessor
    {
        int CheckScore(Score actualScore, Score predictedScore);
    }
}