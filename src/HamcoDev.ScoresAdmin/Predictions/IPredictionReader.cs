namespace HamcoDev.ScoresAdmin.Predictions
{
    using System.Collections.Generic;

    using HamcoDev.ScoresAdmin.Fixtures;
    using HamcoDev.ScoresAdmin.Results;

    public interface IPredictionReader
    {
        List<FixtureResult> GetPredictions(string userId, int matchday);
    }
}
