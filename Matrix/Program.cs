using Matrix;

var input = Console.ReadLine(); // "1,0,1;1,1,0";
var matrix = LoadMatrix(input);
var areasCount = CalculateAreas(matrix);

Console.WriteLine(areasCount);

byte[,] LoadMatrix(string input)
{
    var rows = input.Split(';');
    var width = rows[0].Split(',').Length;

    var result = new byte[rows.Length, width];
    for (var row = 0; row < rows.Length; row++)
    {
        var rowValues = rows[row].Split(',');
        for (var column = 0; column < width; column++)
        {
            result[row, column] = rowValues[column] switch
            {
                "0" => 0,
                "1" => 1,
                _ => throw new Exception("Wrong input given"),
            };
        }
    }

    return result;
}

int CalculateAreas(byte[,] input)
{
    var manager = new AreaManager<DictionaryStorage, TwoDimensionMatchingStrategy>();

    for (var row = 0; row < input.GetLength(0); row++)
    {
        for (var column = 0; column < input.GetLength(1); column++)
        {
            if (input[row, column] == 1)
            {
                manager.Handle((row, column));
            }
        }
        manager.Flush(row);
    }
    manager.Finish();

    return manager.NumberOfFinishedAreas;
}
