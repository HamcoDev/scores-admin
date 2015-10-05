namespace HamcoDev.ScoresAdmin.Results
{
    using System;

    public class FixtureResult
    {
        public DateTime Date { get; set; }

        public Score Score { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }
    }
}