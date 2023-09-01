namespace Matrix
{
    public class DictionaryStorage : IStorage
    {
        private readonly Dictionary<int, List<int>> rowColumns = new Dictionary<int, List<int>>();

        public void Add((int Row, int Column) value)
        {
            if (rowColumns.TryGetValue(value.Row, out var columns))
            {
                columns.Add(value.Column);
            }
            else
            {
                rowColumns.Add(value.Row, new List<int> { value.Column });
            }

        }

        public List<(int Row, int Column)> GetAll()
        {
            return rowColumns.Keys.SelectMany(row => rowColumns[row].Select(column => (row, column))).ToList();
        }

        public bool Has((int Row, int Column) value)
        {
            return rowColumns.TryGetValue(value.Row, out var columns) && columns.Contains(value.Column);
        }

        public bool Has(int row) => rowColumns.Keys.Contains(row);
    }
}

