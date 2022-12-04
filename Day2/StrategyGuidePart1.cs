namespace Day2
{
    public class StrategyGuidePart1
    {
        public StrategyGuidePart1(string[] lines)
        {
            Rounds = lines.Select(line => line.Split(" "))
                .Select(bits => new Round(
                                    opponent: ShapeDecoder.GetShape(bits[0], WhoIsPlaying.Opponent), 
                                    me:       ShapeDecoder.GetShape(bits[1], WhoIsPlaying.Me)))
                .ToList();
        }

        public List<Round> Rounds { get; }

        public class Round
        {
            public Round(Shape opponent, Shape me)
            {
                Opponent = opponent;
                Me = me;
            }

            public Shape Opponent { get; }
            public Shape Me { get; }

            public override string? ToString()
            {
                return $"{Opponent}/{Me}";
            }
        }
    }
}