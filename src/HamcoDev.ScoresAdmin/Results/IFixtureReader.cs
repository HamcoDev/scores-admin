namespace HamcoDev.ScoresAdmin.Results
{
    using System.Collections.Generic;

    public interface IFixtureReader
    {
        List<FixtureResult> GetResults();
    }
}