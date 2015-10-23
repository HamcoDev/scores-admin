using System.Collections.Generic;

namespace HamcoDev.ScoresAdmin
{
    public class PredictionList
    {
        public List<Prediction> fixtures { get; set; }
    }

    public class Prediction
    {
        public int awayPrediction { get; set; }
        public string awayTeam { get; set; }
        public string date { get; set; }
        public int homePrediction { get; set; }
        public string homeTeam { get; set; }
        public string status { get; set; }
    }
}
