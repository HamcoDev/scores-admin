namespace HamcoDev.ScoresAdmin.Fixtures
{
    using System;

    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    public class FixtureResult
    {
        public DateTime Date { get; set; }

        public Score Score { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }
    }
}