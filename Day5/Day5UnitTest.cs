using FluentAssertions;

namespace Day5 
{
    [TestClass]
    public class Day5UnitTest
    {
        [TestMethod]
        public void Part1Example()
        {
            var craneInstructions = ExampleCraneInstructions();

            var result = CratePredictor.CraneMover9000(craneInstructions);

            result.Should().Be("CMZ");
        }

        [TestMethod]
        public void Part1Solution()
        {
            var craneInstructions = File.ReadAllLines("input.txt");

            var result = CratePredictor.CraneMover9000(craneInstructions);

            result.Should().Be("MQSHJMWNH");
        }

        [TestMethod]
        public void Part2Example()
        {
            var craneInstructions = ExampleCraneInstructions();

            var result = CratePredictor.CraneMover9001(craneInstructions);

            result.Should().Be("MCD");
        }

        [TestMethod]
        public void Part2Solution()
        {
            var craneInstructions = File.ReadAllLines("input.txt");

            var result = CratePredictor.CraneMover9001(craneInstructions);

            result.Should().Be("LLWJRBHVZ");
        }

        private string[] ExampleCraneInstructions()
        {
            var example = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
            return example.Split(Environment.NewLine);
        }
    }
}