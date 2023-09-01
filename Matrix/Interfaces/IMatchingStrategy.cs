namespace Matrix
{
    public interface IMatchingStrategy
    {
        public List<(int Row, int Column)> FindPossibleMatches((int Row, int Column) candidate);
    }
}

