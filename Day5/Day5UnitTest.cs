using FluentAssertions;

namespace Day5 
{
    [TestClass]
    public class Day5UnitTest
    {
        [TestMethod]
        public void EnclosingRangeCountExample()
        {
            var craneInstructions = ExampleCraneInstructions();

            var result = CratePredictor.FinalSetup(craneInstructions);

            result.Should().Be("CMZ");
        }
        /*
        [TestMethod]
        public void EnclosingRangeCountSolution()
        {
            var sectionAssignments = File.ReadAllLines("input.txt");

            var result = CratePredictor.EnclosingRangeCount(sectionAssignments);

            result.Should().Be(513);
        }

        [TestMethod]
        public void OverlappingRangeCountExample()
        {
            var sectionAssignments = ExampleSectionAssignments();

            var result = CratePredictor.OverlappingRangeCount(sectionAssignments);

            result.Should().Be(4);
        }

        [DataRow("1-5,6-10", false)]
        [DataRow("6-10,1-5", false)]

        [DataRow("2-5,5-7", true)]
        [DataRow("5-7,2-5", true)]

        [DataRow("40-60,50-70", true)]
        [DataRow("50-70,40-60", true)]

        [DataRow("1-10,4-6", true)]
        [DataRow("4-6,1-10", true)]

        [DataRow("1-1,1-1", true)]
        [DataTestMethod]
        public void OverlappingRangeCountOverlapTypesExample(string sectionAssignment, bool isOverlap)
        {
            var sectionAssignments = new[] { sectionAssignment };

            var result = CratePredictor.OverlappingRangeCount(sectionAssignments);

            var expectedResult = isOverlap ? 1 : 0;
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void OverlappingRangeCountSolution()
        {
            var sectionAssignments = File.ReadAllLines("input.txt");

            var result = CratePredictor.OverlappingRangeCount(sectionAssignments);

            result.Should().Be(878);
        }
        */

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