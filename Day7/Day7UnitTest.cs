using FluentAssertions;

namespace Day7
{
    [TestClass]
    public class Day7UnitTest
    {
        [TestMethod]
        public void Part1Example()
        {
            var buffer = ExampleTerminalOutput();

            var filesystem = FilesystemAnalyser.CreateFilesystem(buffer);
            FilesystemAnalyser.SetFolderSizes(filesystem);
            var result = FilesystemAnalyser.CalculateTotalSize(filesystem, maxDirectorySize: 100000);

            result.Should().Be(95437);
        }

        [TestMethod]
        public void Part1Solution()
        {
            var buffer = File.ReadAllLines("input.txt");

            var filesystem = FilesystemAnalyser.CreateFilesystem(buffer);
            FilesystemAnalyser.SetFolderSizes(filesystem);
            var result = FilesystemAnalyser.CalculateTotalSize(filesystem, maxDirectorySize: 100000);

            result.Should().Be(1491614);
        }

        [TestMethod]
        public void Part2Example()
        {
            var buffer = ExampleTerminalOutput();

            var filesystem = FilesystemAnalyser.CreateFilesystem(buffer);
            FilesystemAnalyser.SetFolderSizes(filesystem);
            var nodeToDelete = FilesystemAnalyser.FindDirectoryToDelete(filesystem, totalDiskSpace: 70000000,  spaceNeeded: 30000000);

            nodeToDelete.Size.Should().Be(24933642);
        }

        [TestMethod]
        public void Part2Solution()
        {
            var buffer = File.ReadAllLines("input.txt");

            var filesystem = FilesystemAnalyser.CreateFilesystem(buffer);
            FilesystemAnalyser.SetFolderSizes(filesystem);
            var nodeToDelete = FilesystemAnalyser.FindDirectoryToDelete(filesystem, totalDiskSpace: 70000000, spaceNeeded: 30000000);

            nodeToDelete.Size.Should().Be(6400111);
        }
        
        private string[] ExampleTerminalOutput()
        {
            var example = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
            return example.Split(Environment.NewLine);
        }
    }
}