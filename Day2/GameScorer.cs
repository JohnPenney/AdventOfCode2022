namespace Day2
{
    public class GameScorer
    {
        public static int ScorePart1(StrategyGuidePart1 strategyGuide)
        {
            var totalScore = 0;
            foreach(var round in strategyGuide.Rounds)
            {
                var roundScore = RoundScore(round.Opponent, round.Me);
                totalScore += roundScore;
            }
            return totalScore;
        }

        public static int ScorePart2(StrategyGuidePart2 strategyGuide)
        {
            var totalScore = 0;
            foreach (var round in strategyGuide.Rounds)
            {
                var myShape = GetMyShape(round.Opponent, round.Outcome);

                var roundScore = RoundScore(round.Opponent, myShape);
                totalScore += roundScore;
            }
            return totalScore;
        }

        private static int RoundScore(Shape opponent, Shape me)
        {
            var myScore = ShapeScore(me);
            var outcome = GetOutcome(opponent, me);
            var outcomeScore = OutcomeScore(outcome);
            return myScore + outcomeScore;
        }

        private static Shape GetMyShape(Shape opponent, Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.Draw:
                    return opponent;
                case Outcome.MyWin:
                    {
                        switch (opponent)
                        {
                            case Shape.Rock:
                                return Shape.Paper;
                            case Shape.Paper:
                                return Shape.Scissors;
                            case Shape.Scissors:
                                return Shape.Rock;
                        }
                        throw new NotImplementedException();
                    }
                case Outcome.OpponentWin:
                    {
                        switch (opponent)
                        {
                            case Shape.Rock:
                                return Shape.Scissors;
                            case Shape.Paper:
                                return Shape.Rock;
                            case Shape.Scissors:
                                return Shape.Paper;
                        }
                        throw new NotImplementedException();
                    }
            }
            throw new NotImplementedException();
        }

        private static int ShapeScore(Shape shape)
        {
            switch (shape)
            {
                case Shape.Rock:
                    return 1;
                case Shape.Paper:
                    return 2;
                case Shape.Scissors:
                    return 3;
            }
            throw new NotImplementedException();
        }

        private static int OutcomeScore(Outcome outcome)
        {
            switch (outcome)
            {
                case Outcome.OpponentWin:
                    return 0;
                case Outcome.Draw:
                    return 3;
                case Outcome.MyWin:
                    return 6;
            }
            throw new NotImplementedException();
        }

        private static Outcome GetOutcome(Shape opponent, Shape me)
        {
            if (opponent == me)
                return Outcome.Draw;

            switch (opponent)
            {
                case Shape.Rock:
                    return me == Shape.Paper ? Outcome.MyWin : Outcome.OpponentWin;
                case Shape.Paper:
                    return me == Shape.Scissors ? Outcome.MyWin : Outcome.OpponentWin;
                case Shape.Scissors:
                    return me == Shape.Rock ? Outcome.MyWin : Outcome.OpponentWin;
            }
            throw new NotImplementedException();
        }
    }
}