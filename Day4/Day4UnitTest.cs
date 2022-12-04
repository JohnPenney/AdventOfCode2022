using FluentAssertions;

namespace Day4
{
    [TestClass]
    public class Day4UnitTest
    {
        [TestMethod]
        public void EnclosingRangeCountExample()
        {
            var sectionAssignments = ExampleSectionAssignments();

            var result = SectionAnalyzer.EnclosingRangeCount(sectionAssignments);

            result.Should().Be(2);
        }
        
        [TestMethod]
        public void EnclosingRangeCountSolution()
        {
            var sectionAssignments = File.ReadAllLines("input.txt");

            var result = SectionAnalyzer.EnclosingRangeCount(sectionAssignments);

            result.Should().Be(513);
        }

        [TestMethod]
        public void OverlappingRangeCountExample()
        {
            var sectionAssignments = ExampleSectionAssignments();

            var result = SectionAnalyzer.OverlappingRangeCount(sectionAssignments);

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

            var result = SectionAnalyzer.OverlappingRangeCount(sectionAssignments);

            var expectedResult = isOverlap ? 1 : 0;
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        public void OverlappingRangeCountSolution()
        {
            var sectionAssignments = File.ReadAllLines("input.txt");

            var result = SectionAnalyzer.OverlappingRangeCount(sectionAssignments);

            result.Should().Be(878);
        }

        private string[] ExampleSectionAssignments()
        {
            var example = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";
            return example.Split(Environment.NewLine);
        }
    }
}