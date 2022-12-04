using FluentAssertions;

namespace Day2
{
    [TestClass]
    public class UnitTestPart2
    {
        [TestMethod]
        public void ScoreExample()
        {
            var strategyGuide = new StrategyGuidePart2(ExampleGuide());

            var result = GameScorer.ScorePart2(strategyGuide);

            result.Should().Be(12);
        }

        [DataRow("A X", 3 + 0)]
        [DataRow("A Y", 1 + 3)]
        [DataRow("A Z", 2 + 6)]
        [DataRow("B X", 1 + 0)]
        [DataRow("B Y", 2 + 3)]
        [DataRow("B Z", 3 + 6)]
        [DataRow("C X", 2 + 0)]
        [DataRow("C Y", 3 + 3)]
        [DataRow("C Z", 1 + 6)]
        [TestMethod]
        public void ScoreARound(string line, int expectedScore)
        {
            var strategyGuide = new StrategyGuidePart2(new[] { line });

            var result = GameScorer.ScorePart2(strategyGuide);

            result.Should().Be(expectedScore);
        }

        [TestMethod]
        public void ScoreSolution()
        {
            var input = File.ReadAllLines("input.txt");
            var strategyGuide = new StrategyGuidePart2(input);

            var result = GameScorer.ScorePart2(strategyGuide);

            result.Should().Be(12881);
        }


        private string[] ExampleGuide()
        {
            var text = @"A Y
B X
C Z";
            return text.Split(Environment.NewLine);
        }
    }
}