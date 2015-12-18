namespace HamcoDev.ScoresAdmin.Scores
{
    using HamcoDev.ScoresAdmin.Common;

    using Newtonsoft.Json;

    public class ScoresWriter : IScoresWriter
    {
        private readonly IFirebase firebase;

        public ScoresWriter()
        {
            this.firebase = new Firebase();
        }

        public string WriteMatchdayScores(string userId, int matchday, int points)
        {
            return this.firebase.Write($"/scores/user/{userId}/matchday/{matchday}/points.json", points.ToString());
        }

        public void WriteTotalScores(string userId, int totalScore)
        {
            this.firebase.Write($"/scores/user/{userId}/totalPoints.json", totalScore.ToString());
        }
    }
}