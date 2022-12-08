using FluentAssertions;

namespace Day8
{
    [TestClass]
    public class Day8UnitTest
    {
        [TestMethod]
        public void Part1Example()
        {
            var buffer = ExampleTreeGrid();

            var result = TreeScrutineer.CountVisibleTrees(buffer);

            result.Should().Be(21);
        }

        [TestMethod]
        public void Part1Solution()
        {
            var buffer = File.ReadAllLines("input.txt");

            var result = TreeScrutineer.CountVisibleTrees(buffer);

            result.Should().Be(1546);
        }

        [TestMethod]
        public void Part2Example()
        {
            var buffer = ExampleTreeGrid();

            var result = TreeScrutineer.GetBestScenicScore(buffer);

            result.Should().Be(8);
        }

        /*
        [TestMethod]
        public void Part2Solution()
        {
            var buffer = File.ReadAllLines("input.txt");

            var filesystem = FilesystemAnalyser.CreateFilesystem(buffer);
            FilesystemAnalyser.SetFolderSizes(filesystem);
            var nodeToDelete = FilesystemAnalyser.FindDirectoryToDelete(filesystem, totalDiskSpace: 70000000, spaceNeeded: 30000000);

            nodeToDelete.Size.Should().Be(6400111);
        }
        */
        private string[] ExampleTreeGrid()
        {
            var example = @"30373
25512
65332
33549
35390";
            return example.Split(Environment.NewLine);
        }
    }
}