namespace Day2
{
    public class StrategyGuidePart2
    {
        public StrategyGuidePart2(string[] lines)
        {
            Rounds = lines.Select(line => line.Split(" "))
                .Select(bits => new Round(
                                    opponent: ShapeDecoder.GetShape(bits[0], WhoIsPlaying.Opponent),
                                    outcome:  OutcomeDecoder.GetOutcome(bits[1])))
                .ToList();
        }

        public List<Round> Rounds { get; }

        public class Round
        {
            public Round(Shape opponent, Outcome outcome)
            {
                Opponent = opponent;
                Outcome = outcome;
            }

            public Shape Opponent { get; }
            public Outcome Outcome { get; }

            public override string? ToString()
            {
                return $"{Opponent}/{Outcome}";
            }
        }
    }
}