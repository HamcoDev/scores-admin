namespace HamcoDev.ScoresAdmin.Fixtures
{
    using System.Collections.Generic;

    public interface IFixtureReader
    {
        List<FixtureResult> GetResults(int matchday);
    }
}