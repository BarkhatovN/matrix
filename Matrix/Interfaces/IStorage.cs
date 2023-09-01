namespace Matrix
{
    public interface IStorage
    {
        void Add((int Row, int Column) value);
        bool Has((int Row, int Column) value);
        bool Has(int row);
        List<(int Row, int Column)> GetAll();
    }
}

