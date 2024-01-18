var grid = new Grid(File.ReadAllLines("input.txt"));
Console.WriteLine(grid.Result());

internal class Grid(string[] input)
{
    private readonly Dictionary<(int x, int y), int> _grid = input.SelectMany((line, y) => line.Split(' ').Select((c, x) => (c, x, y)))
        .ToDictionary(x => (x.x, x.y), x => int.Parse(x.c.ToString()));

    public int Result()
    {
        var max = 0;
        foreach (var (x, y) in _grid.Keys)
        {
            max = Math.Max(max, GetProduct(x, y, 1, 0));
            max = Math.Max(max, GetProduct(x, y, 0, 1));
            max = Math.Max(max, GetProduct(x, y, 1, 1));
            max = Math.Max(max, GetProduct(x, y, 1, -1));
        }

        return max;
    }

    private int GetProduct(int x, int y, int dx, int dy)
    {
        var product = 1;
        for (var i = 0; i < 4; i++)
        {
            if (!_grid.TryGetValue((x + i * dx, y + i * dy), out var value))
                return 0;
            product *= value;
        }

        return product;
    }
}




