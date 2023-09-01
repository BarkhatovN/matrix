namespace Matrix
{
    public class AreaManager<Storage, MatchingStrategy>
        where Storage : IStorage, new()
        where MatchingStrategy : IMatchingStrategy, new()
    {
        private readonly List<Area> areas = new();
        private int finishedAreaNumber = 0;

        public int NumberOfFinishedAreas => finishedAreaNumber;

        public void Handle((int Row, int Column) value)
        {
            var stageAreas = areas.Where(area => area.Match(value)).ToList();

            if (stageAreas.Count > 1)
            {
                var first = stageAreas.First();
                first.Add(value);

                foreach (var duplicateArea in stageAreas.Skip(1))
                {
                    first.Merge(duplicateArea);
                    areas.Remove(duplicateArea);
                }
            }
            else if (stageAreas.Count == 1)
            {
                var first = stageAreas.First();
                first.Add(value);
            }
            else
            {
                var area = new Area(new Storage(), new MatchingStrategy());
                area.Add(value);
                areas.Add(area);
            }
        }

        public void Flush(int lastRow)
        {
            areas.ToList().ForEach(area =>
            {
                if (area.Finished(lastRow))
                {
                    areas.Remove(area);
                    finishedAreaNumber++;
                }
            });
        }


        public void Finish()
        {
            areas.ToList().ForEach(area =>
            {
                areas.Remove(area);
                finishedAreaNumber++;
            });
        }
    }
}

