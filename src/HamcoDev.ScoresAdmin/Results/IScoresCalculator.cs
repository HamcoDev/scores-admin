namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;

    public interface IScoresCalculator
    {
        int Calculate(List<FixtureResult> predictedResults, List<FixtureResult> actualResults);
    }
}