namespace HamcoDev.ScoresAdmin.Scores
{
    using System.Collections.Generic;

    using HamcoDev.ScoresAdmin.Fixtures;

    public interface IScoresCalculator
    {
        int Calculate(List<FixtureResult> predictedResults, List<FixtureResult> actualResults);
    }
}