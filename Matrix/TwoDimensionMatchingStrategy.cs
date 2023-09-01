namespace Matrix
{
    public class TwoDimensionMatchingStrategy : IMatchingStrategy
    {
        public List<(int Row, int Column)> FindPossibleMatches((int Row, int Column) candidate)
        {
            var result = new List<(int Row, int Column)>();

            // right neighbour
            if (candidate.Column > 0)
            {
                result.Add((candidate.Row, candidate.Column - 1));
            }

            // bottom neighbour
            if (candidate.Row > 0)
            {
                result.Add((candidate.Row - 1, candidate.Column));
            }

            return result;
        }
    }
}

