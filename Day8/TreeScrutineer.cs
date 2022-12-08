namespace Day8
{
    public static class TreeScrutineer
    {
        public static int CountVisibleTrees(string[] treeGrid)
        {
            var numRows = treeGrid.Length;
            var numCols = treeGrid[0].Length;
            var numTrees = numRows * numCols;

            var invisibleTreeCount = 0;
            for (var rowIndex = 1; rowIndex < numRows - 1; ++rowIndex)
            {
                for(var colIndex = 1; colIndex < numCols-1; ++colIndex )
                {
                    var thisTreeHeight = treeGrid[rowIndex][colIndex] - '0';
                    var numTreesToLeft = colIndex;
                    var isInvisibleFromLeft = Enumerable.Range(0, numTreesToLeft).Any(x => treeGrid[rowIndex][x] - '0' >= thisTreeHeight);

                    var numTreesToRight = numCols - colIndex - 1;
                    var isInvisibleFromRight = Enumerable.Range(colIndex + 1, numTreesToRight).Any(x => treeGrid[rowIndex][x] - '0' >= thisTreeHeight);

                    var numTreesAbove = rowIndex;
                    var isInvisibleFromAbove = Enumerable.Range(0, numTreesAbove).Any(x => treeGrid[x][colIndex] - '0' >= thisTreeHeight);

                    var numTreesBelow = numRows - rowIndex - 1;
                    var isInvisibleFromBelow = Enumerable.Range(rowIndex + 1, numTreesBelow).Any(x => treeGrid[x][colIndex] - '0' >= thisTreeHeight);

                    if (isInvisibleFromLeft && isInvisibleFromRight && isInvisibleFromAbove && isInvisibleFromBelow)
                        ++invisibleTreeCount;
                }
            }
            return numTrees - invisibleTreeCount;
        }
        public static int GetBestScenicScore(string[] treeGrid)
        {
            var numRows = treeGrid.Length;
            var numCols = treeGrid[0].Length;
            var numTrees = numRows * numCols;

            var bestScenicScore = 0;
            for (var rowIndex = 1; rowIndex < numRows - 1; ++rowIndex)
            {
                for (var colIndex = 1; colIndex < numCols - 1; ++colIndex)
                {
                    var thisTreeHeight = treeGrid[rowIndex][colIndex] - '0';
                    var numTreesToLeft = colIndex;
                    var visibleToLeft = Enumerable.Range(0, numTreesToLeft).Reverse().TakeWhile(x => treeGrid[rowIndex][x] - '0' < thisTreeHeight).Count() + 1;

                    var numTreesToRight = numCols - colIndex - 1;
                    var visibleToRight = Enumerable.Range(colIndex + 1, numTreesToRight).Reverse().TakeWhile(x => treeGrid[rowIndex][x] - '0' >= thisTreeHeight).Count() + 1;

                    var numTreesAbove = rowIndex;
                    var visibleFromAbove = Enumerable.Range(0, numTreesAbove).Reverse().TakeWhile(x => treeGrid[x][colIndex] - '0' >= thisTreeHeight).Count() + 1;

                    var numTreesBelow = numRows - rowIndex - 1;
                    var visibleFromBelow = Enumerable.Range(rowIndex + 1, numTreesBelow).Reverse().TakeWhile(x => treeGrid[x][colIndex] - '0' >= thisTreeHeight).Count() + 1;

                    var scenicScore = visibleToLeft * visibleToRight * visibleFromAbove * visibleFromBelow;
                    if (scenicScore > bestScenicScore)
                        bestScenicScore = scenicScore;
                }
            }
            return bestScenicScore;
        }
    }
}