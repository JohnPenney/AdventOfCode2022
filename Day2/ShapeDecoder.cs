namespace Day2
{
    public class ShapeDecoder
    {
        public static Shape GetShape(string codeStr, WhoIsPlaying whoIsPlaying)
        {
            if (string.IsNullOrEmpty(codeStr))
                throw new NotImplementedException();
            if (codeStr.Length != 1)
                throw new NotImplementedException();

            switch (whoIsPlaying)
            {
                case WhoIsPlaying.Opponent:
                    return GetOpponentShape(codeStr[0]);
                case WhoIsPlaying.Me:
                    return GetMyShape(codeStr[0]);
            }
            throw new NotSupportedException();
        }
        private static Shape GetOpponentShape(char code)
        {
            if (code == 'A')
                return Shape.Rock;
            if (code == 'B')
                return Shape.Paper;
            if (code == 'C')
                return Shape.Scissors;
            throw new NotSupportedException();
        }
        private static Shape GetMyShape(char code)
        {
            if (code == 'X')
                return Shape.Rock;
            if (code == 'Y')
                return Shape.Paper;
            if (code == 'Z')
                return Shape.Scissors;
            throw new NotSupportedException();
        }
    }
}