using FluentAssertions;

namespace Day1
{
    [TestClass]
    public class Day1UnitTest
    {
        [TestMethod]
        public void FattestElfExample()
        {
            var calorieList = ExampleCalorieList();

            var calories = CalorieCalculator.FattestElf(calorieList);

            calories.Should().Be(24000);
        }

        [TestMethod]
        public void FattestElfSolution()
        {
            var calorieList = File.ReadAllLines("input.txt");

            var calories = CalorieCalculator.FattestElf(calorieList);

            calories.Should().Be(70613);
        }

        [TestMethod]
        public void Fattest3ElvesExample()
        {
            var calorieList = ExampleCalorieList();

            var calories = CalorieCalculator.Fattest3Elves(calorieList);

            calories.Should().Be(45000);
        }

        [TestMethod]
        public void Fattest3ElvesSolution()
        {
            var calorieList = File.ReadAllLines("input.txt");

            var calories = CalorieCalculator.Fattest3Elves(calorieList);

            calories.Should().Be(205805);
        }
        
        private string[] ExampleCalorieList()
        {
            var example = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
            return example.Split(Environment.NewLine);
        }
    }
}