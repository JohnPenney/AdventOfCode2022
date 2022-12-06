using FluentAssertions;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Day6
{
    [TestClass]
    public class Day6UnitTest
    {
        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        [DataTestMethod]
        public void Part1Example(string buffer, int expectedEndOfStartPacketMarker)
        {
            var result = MessageAnalyser.FindEndOfPacketMarker(buffer);

            result.Should().Be(expectedEndOfStartPacketMarker);
        }

        [TestMethod]
        public void Part1Solution()
        {
            var buffer = File.ReadAllLines("input.txt");
            if (buffer.Length != 1) throw new NotSupportedException();

            var result = MessageAnalyser.FindEndOfPacketMarker(buffer[0]);

            result.Should().Be(1816);
        }

        [DataRow("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [DataRow("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [DataRow("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [DataRow("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [DataRow("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        [DataTestMethod]
        public void Part2Example(string buffer, int expectedEndOfStartPacketMarker)
        {
            var result = MessageAnalyser.FindEndOfMessageMarker(buffer);

            result.Should().Be(expectedEndOfStartPacketMarker);
        }

        [TestMethod]
        public void Part2Solution()
        {
            var buffer = File.ReadAllLines("input.txt");
            if (buffer.Length != 1) throw new NotSupportedException();

            var result = MessageAnalyser.FindEndOfMessageMarker(buffer[0]);

            result.Should().Be(2625);
        }
    }
}