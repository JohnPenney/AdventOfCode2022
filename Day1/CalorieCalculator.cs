namespace Day1
{
    public static class CalorieCalculator
    {
        public static int FattestElf(IEnumerable<string> calorieList)
        {
            var buckets = Bucketize(calorieList);
            var totals = buckets.Select(b => b.Sum(x => int.Parse(x))).ToList();
            var biggestBucket = totals.OrderBy(x => x).Last();

            return biggestBucket;
        }

        public static int Fattest3Elves(IEnumerable<string> calorieList)
        {
            var buckets = Bucketize(calorieList);
            var totals = buckets.Select(b => b.Sum(x => int.Parse(x))).ToList();
            var last3Total = totals.OrderByDescending(x => x).Take(3).Sum();

            return last3Total;
        }

        private static List<List<string>> Bucketize(IEnumerable<string> calorieList)
        {
            var buckets = new List<List<string>>();
            buckets.Add(new List<string>());
            foreach (var calorieLine in calorieList)
            {
                if (string.IsNullOrEmpty(calorieLine))
                {

                    buckets.Add(new List<string>());
                }
                else
                {
                    buckets.Last().Add(calorieLine);
                }

            }
            return buckets;
        }
    }
}