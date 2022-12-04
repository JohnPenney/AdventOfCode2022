using FluentAssertions;

namespace Day3
{
    [TestClass]
    public class Day3UnitTest
    {
        [DataRow('p', 16)]
        [DataRow('L', 38)]
        [DataRow('P', 42)]
        [DataRow('s', 19)]
        [DataTestMethod]
        public void ContentPriority(char content, int expectedPriority)
        {
            var result = RucksackBalancer.PriorityOf(content);

            result.Should().Be(expectedPriority);
        }

        [TestMethod]
        public void CommonItemsPrioritySumExample()
        {
            var rucksackList = ExampleRucksackList();

            var result = RucksackBalancer.CalculatePrioritySum(rucksackList);

            result.Should().Be(157);
        }

        [TestMethod]
        public void CommonItemsPrioritySumSolution()
        {
            var rucksackList = File.ReadAllLines("input.txt");

            var result = RucksackBalancer.CalculatePrioritySum(rucksackList);

            result.Should().Be(7793);
        }

        [TestMethod]
        public void BadgesExample()
        {
            var rucksackList = ExampleRucksackList();

            var result = RucksackBalancer.CalculateBadgeSum(rucksackList);

            result.Should().Be(70);
        }

        [TestMethod]
        public void BadgesSolution()
        {
            var rucksackList = File.ReadAllLines("input.txt");

            var result = RucksackBalancer.CalculateBadgeSum(rucksackList);

            result.Should().Be(2499);
        }

        private string[] ExampleRucksackList()
        {
            var example = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";
            return example.Split(Environment.NewLine);
        }
    }
}