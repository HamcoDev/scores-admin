namespace HamcoDev.ScoresAdmin.Predictions
{
    using System.Collections.Generic;

    public class Fixture
    {
        public int awayPrediction { get; set; }
        public string awayTeam { get; set; }
        public string date { get; set; }
        public int homePrediction { get; set; }
        public string homeTeam { get; set; }
        public string status { get; set; }
    }

    public class RootObject
    {
        public List<Fixture> fixture { get; set; }
    }
}