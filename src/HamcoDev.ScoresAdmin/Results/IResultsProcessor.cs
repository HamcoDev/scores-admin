namespace HamcoDev.ScoresAdmin.Results
{
    using HamcoDev.ScoresAdmin.Scores;

    public interface IResultsProcessor
    {
        int CheckScore(Score predictedScore, Score actualScore);
    }
}