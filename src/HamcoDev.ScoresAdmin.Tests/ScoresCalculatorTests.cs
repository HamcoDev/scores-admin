namespace HamcoDev.ScoresAdmin.Tests
{
    using System;
    using System.Collections.Generic;

    using HamcoDev.ScoresAdmin.Results;

    using Moq;

    using Xunit;

    public class ScoresCalculatorTests
    {
        private const string HomeTeamA = "HomeTeamA";
        private const string AwayTeamA = "AwayTeamA";
        private const string HomeTeamB = "HomeTeamB";
        private const string AwayTeamB = "AwayTeamB";

        private Mock<IResultsProcessor> mockResultsProcessor;

        public ScoresCalculatorTests()
        {
            this.mockResultsProcessor = new Mock<IResultsProcessor>();
        }

        [Fact]
        public void BothPredictionsIncorrectReturnsZeroPoints()
        {
            var scoresCalculator = new ScoresCalculator(this.mockResultsProcessor.Object);

            var actualResults = new List<FixtureResult>();
            var predictedResults = new List<FixtureResult>();

            var matchDate = DateTime.UtcNow;

            predictedResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamA,
                AwayTeam = AwayTeamA,
                Score = new Score
                {
                    Home = 2,
                    Away = 1
                },
                Date = matchDate
            });

            predictedResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamB,
                AwayTeam = AwayTeamB,
                Score = new Score
                {
                    Home = 4,
                    Away = 0
                },
                Date = matchDate
            });

            actualResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamA,
                AwayTeam = AwayTeamA,
                Score = new Score
                {
                    Home = 1,
                    Away = 1
                },
                Date = matchDate
            });

            actualResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamB,
                AwayTeam = AwayTeamB,
                Score = new Score
                {
                    Home = 2,
                    Away = 1
                },
                Date = matchDate
            });

            this.mockResultsProcessor.Setup(x => x.CheckScore(It.IsAny<Score>(), It.IsAny<Score>())).Returns(0);

            var result = scoresCalculator.Calculate(predictedResults, actualResults);
            Assert.Equal(0, result);
        }

        [Fact]
        private void MissingHomeTeamThrowsException()
        {
            var scoresCalculator = new ScoresCalculator(this.mockResultsProcessor.Object);

            var actualResults = new List<FixtureResult>();
            var predictedResults = new List<FixtureResult>();

            var matchDate = DateTime.UtcNow;

            predictedResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamA,
                AwayTeam = AwayTeamA,
                Score = new Score
                {
                    Home = 2,
                    Away = 1
                },
                Date = matchDate
            });

            actualResults.Add(new FixtureResult
            {
                HomeTeam = HomeTeamB,
                AwayTeam = AwayTeamA,
                Score = new Score
                {
                    Home = 1,
                    Away = 1
                },
                Date = matchDate
            });

            this.mockResultsProcessor.Setup(x => x.CheckScore(It.IsAny<Score>(), It.IsAny<Score>())).Returns(0);

            Assert.Throws<Exception>(() => scoresCalculator.Calculate(predictedResults, actualResults));
        }
    }
}