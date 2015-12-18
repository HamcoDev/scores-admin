namespace HamcoDev.ScoresAdmin.Scores
{
    public interface IScoresWriter
    {
        string WriteMatchdayScores(string userId, int matchday, int points);

        void WriteTotalScores(string userId, int matchdayTotal);
    }
}