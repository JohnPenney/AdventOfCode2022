using System.Security.AccessControl;

namespace Day3
{
    public static class RucksackBalancer
    {
        public static int CalculatePrioritySum(string[] rucksackList)
        {
            var result = 0;
            foreach(var rucksack in rucksackList)
            {
                var compartmentSize = rucksack.Length / 2;
                var compartmentA = rucksack.Take(compartmentSize).ToList();
                var compartmentB = rucksack.Skip(compartmentSize).ToList();
                var commonItems = compartmentA.Intersect(compartmentB).ToList();
                var commonItemPrioritySum = commonItems.Sum(PriorityOf);
                result += commonItemPrioritySum;
            }
            return result;
        }

        public static int CalculateBadgeSum(string[] rucksackList)
        {
            var result = 0;
            foreach (var batch in Batch(rucksackList))
            {
                var commonItems = batch[0].Intersect(batch[1]).Intersect(batch[2]).ToList();
                var commonItemPrioritySum = commonItems.Sum(PriorityOf);
                result += commonItemPrioritySum;
            }
            return result;
        }

        private static IEnumerable<string[]> Batch(string[] rucksackList)
        {
            var i = 0;
            while (i < rucksackList.Length)
            {
                yield return new[] { rucksackList[i++], rucksackList[i++], rucksackList[i++] };
            }
        }

        public static int PriorityOf(char c)
        {
            if (c >= 'a' && c <= 'z')
                return c - 'a' + 1;
            if (c >= 'A' && c <= 'Z')
                return c - 'A' + 27;
            throw new NotImplementedException();

        }
    }
}