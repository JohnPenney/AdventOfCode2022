using FluentAssertions;

namespace Day2
{
    [TestClass]
    public class UnitTestPart1
    {
        [TestMethod]
        public void ScoreExample()
        {
            var strategyGuide = new StrategyGuidePart1(ExampleGuide());

            var result = GameScorer.ScorePart1(strategyGuide);

            result.Should().Be(15);
        }

        [DataRow("A X", 1 + 3)]
        [DataRow("A Y", 2 + 6)]
        [DataRow("A Z", 3 + 0)]
        [DataRow("B X", 1 + 0)]
        [DataRow("B Y", 2 + 3)]
        [DataRow("B Z", 3 + 6)]
        [DataRow("C X", 1 + 6)]
        [DataRow("C Y", 2 + 0)]
        [DataRow("C Z", 3 + 3)]
        [TestMethod]
        public void ScoreARound(string line, int expectedScore)
        {
            var strategyGuide = new StrategyGuidePart1(new[] { line });

            var result = GameScorer.ScorePart1(strategyGuide);

            result.Should().Be(expectedScore);
        }

        [TestMethod]
        public void ScoreSolution()
        {
            var input = File.ReadAllLines("input.txt");
            var strategyGuide = new StrategyGuidePart1(input);

            var result = GameScorer.ScorePart1(strategyGuide);

            result.Should().Be(13682);
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