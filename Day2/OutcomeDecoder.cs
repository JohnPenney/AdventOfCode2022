namespace Day2
{
    public class OutcomeDecoder
    {
        public static Outcome GetOutcome(string codeStr)
        {
            if (string.IsNullOrEmpty(codeStr))
                throw new NotImplementedException();
            if (codeStr.Length != 1)
                throw new NotImplementedException();

            var code = codeStr[0];
            if (code == 'X')
                return Outcome.OpponentWin;
            if (code == 'Y')
                return Outcome.Draw;
            if (code == 'Z')
                return Outcome.MyWin;
            throw new NotSupportedException();
        }
    }
}