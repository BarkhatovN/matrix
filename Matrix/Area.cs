namespace Matrix
{
    public class Area
    {
        private IStorage storage;
        private readonly IMatchingStrategy matchingStrategy;

        private List<(int Row, int Column)> GetValues()
        {
            return storage.GetAll();
        }

        public Area(IStorage storage, IMatchingStrategy matchingStrategy)
        {
            this.storage = storage;
            this.matchingStrategy = matchingStrategy;
        }

        public bool Match((int Row, int Column) candidate)
        {
            var candidates = matchingStrategy.FindPossibleMatches(candidate);

            return candidates.Any(storage.Has);
        }

        public void Add((int Row, int Column) value)
        {
            storage.Add(value);
        }

        public void Merge(Area area)
        {
            area.GetValues().ForEach(storage.Add);
        }

        public bool Finished(int row)
        {
            return !storage.Has(row);
        }
    }
}

