
using System.ComponentModel.DataAnnotations;

namespace Day4
{
    public static class SectionAnalyzer
    {
        public static int EnclosingRangeCount(string[] sectionAssignments)
        {
            var result = 0;
            foreach (var sectionAssignment in sectionAssignments)
            {
                ((var elfAStart, var elfAEnd), (var elfBStart, var elfBEnd)) = GetSectionRanges(sectionAssignment);

                var isBInA = elfAStart <= elfBStart && elfBEnd <= elfAEnd;
                var isAInB = elfBStart <= elfAStart && elfAEnd <= elfBEnd;

                if (isAInB || isBInA) ++result;
            }
            return result;
        }

        public static int OverlappingRangeCount(string[] sectionAssignments)
        {
            var result = 0;
            foreach (var sectionAssignment in sectionAssignments)
            {
                ((var elfAStart, var elfAEnd), (var elfBStart, var elfBEnd)) = GetSectionRanges(sectionAssignment);

                var elfASections = Enumerable.Range(elfAStart, (elfAEnd - elfAStart + 1));
                var elfBSections = Enumerable.Range(elfBStart, (elfBEnd - elfBStart + 1));
                var isOverlap = elfASections.Intersect(elfBSections).Any();

                if (isOverlap) ++result;
            }
            return result;
        }

        private static ((int, int), (int, int)) GetSectionRanges(string sectionAssignment)
        {
            var bits = sectionAssignment.Split(",");
            if (bits.Length != 2)
                throw new NotImplementedException();

            var elfARange = bits[0];
            var elfBRange = bits[1];

            return (GetSectionRange(elfARange), GetSectionRange(elfBRange));
        }

        private static (int, int) GetSectionRange(string sectionRange)
        {
            var bits = sectionRange.Split("-");
            if (bits.Length != 2)
                throw new NotImplementedException();

            return (int.Parse(bits[0]), int.Parse(bits[1]));
        }
    }
}