
namespace Day5
{
    public static class CratePredictor
    {
        public static string CraneMover9000(string[] craneInstructions)
        {
            (var crates, var instructions) = Parse(craneInstructions);

            Rearrange9000(crates, instructions);

            return ReportCrateTops(crates);
        }

        public static string CraneMover9001(string[] craneInstructions)
        {
            (var crates, var instructions) = Parse(craneInstructions);

            Rearrange9001(crates, instructions);

            return ReportCrateTops(crates);
        }

        private static string ReportCrateTops(List<Stack<char>> crates)
        {
            var tops = crates.Select(x => x.Peek()).ToArray();
            return new string(tops);
        }

        private static void Rearrange9000(List<Stack<char>> crates, IEnumerable<(int, int, int)> instructions)
        {
            foreach(var instruction in instructions)
            {
                var numCratesToMove = instruction.Item1;
                var sourceStack = instruction.Item2 - 1;
                var destinationStack = instruction.Item3 - 1;
                for(var i = 0; i < numCratesToMove; ++i)
                {
                    var supply = crates[sourceStack].Pop();
                    crates[destinationStack].Push(supply);
                }
            }
        }

        private static void Rearrange9001(List<Stack<char>> crates, IEnumerable<(int, int, int)> instructions)
        {
            foreach (var instruction in instructions)
            {
                var numCratesToMove = instruction.Item1;
                var sourceStack = instruction.Item2 - 1;
                var destinationStack = instruction.Item3 - 1;

                var cratesToMove = Enumerable.Range(1, numCratesToMove)
                                             .Select(i => crates[sourceStack].Pop())
                                             .ToList();

                cratesToMove
                    .AsEnumerable()
                    .Reverse()
                    .ToList()
                    .ForEach(crate => crates[destinationStack].Push(crate));
            }
        }

        private static (List<Stack<char>>, List<(int, int, int)>) Parse(string[] craneInstructions)
        {
            var crateLines = craneInstructions.TakeWhile(x => !string.IsNullOrEmpty(x)).ToList();
            var instructionLines = craneInstructions.Skip(crateLines.Count+1).ToList();

            List<Stack<char>> crates = ParseCrates(crateLines);
            List<(int, int, int)> instructions = ParseInstructions(instructionLines);
            return (crates, instructions);
        }

        private static List<Stack<char>> ParseCrates(List<string> crateLines)
        {
            int numStacks = (crateLines[0].Length + 1)/ 4;
            var result = Enumerable.Range(1, numStacks)
                                   .Select(i => new Stack<char>())
                                   .ToList();

            Func<int, int> stackIndexToCharIndexFn = stackIndex => (4*stackIndex) + 1;
            foreach(var crateLine in crateLines.AsEnumerable().Reverse())
            {
                for(var i = 0; i < numStacks; i++)
                {
                    var charIndex = stackIndexToCharIndexFn(i);
                    var supplyType = crateLine[charIndex];
                    if (supplyType != ' ')
                        result[i].Push(supplyType);
                }
            }

            return result;
        }

        private static List<(int, int, int)> ParseInstructions(List<string> instructionLines)
        {
            return instructionLines
                .Select(x => x.Split(" "))
                .Select(bits => (int.Parse(bits[1]), int.Parse(bits[3]), int.Parse(bits[5])))
                .ToList();
        }
    }
}