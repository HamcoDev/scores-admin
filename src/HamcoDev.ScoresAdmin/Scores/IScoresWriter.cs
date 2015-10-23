namespace HamcoDev.ScoresAdmin.Scores
{
    public interface IScoresWriter
    {
        string WriteScores(string userId, int matchday, int points);
    }
}