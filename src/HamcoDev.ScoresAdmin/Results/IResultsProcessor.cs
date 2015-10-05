namespace HamcoDev.ScoresAdmin.Results
{
    public interface IResultsProcessor
    {
        int CheckScore(Score predictedScore, Score actualScore);
    }
}