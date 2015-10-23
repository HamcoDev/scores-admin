namespace HamcoDev.ScoresAdmin.Tests
{
    using HamcoDev.ScoresAdmin.Results;
    using HamcoDev.ScoresAdmin.Scores;

    using Xunit;

    public class ResultsProcessorTests
    {
        [Fact]
        public void CorrectScoreAssignsThreePoints()
        {
            var resultsProcessor = new ResultsProcessor();

            var actualScore = new Score
            {
                Home = 2,
                Away = 2
            };

            var predictedScore = new Score
            {
                Home = 2,
                Away = 2
            };

            var result = resultsProcessor.CheckScore(actualScore, predictedScore);
            
            Assert.Equal(3, result);
        }

        [Fact]
        public void CorrectResultWrongScoreAssignsOnePoint()
        {
            var resultsProcessor = new ResultsProcessor();

            var actualScore = new Score
            {
                Home = 1,
                Away = 0
            };

            var predictedScore = new Score
            {
                Home = 2,
                Away = 1
            };

            var result = resultsProcessor.CheckScore(actualScore, predictedScore);

            Assert.Equal(1, result);
        }

        [Fact]
        public void IncorrectResultAssignsZeroPoint()
        {
            var resultsProcessor = new ResultsProcessor();

            var actualScore = new Score
            {
                Home = 1,
                Away = 0
            };

            var predictedScore = new Score
            {
                Home = 1,
                Away = 1
            };

            var result = resultsProcessor.CheckScore(actualScore, predictedScore);

            Assert.Equal(0, result);
        }
    }
}