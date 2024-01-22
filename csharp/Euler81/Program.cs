var input = File.ReadAllLines("input.txt");

Dictionary<(int, int), int> grid = input.SelectMany((row, y) => row.Split(',').Select((c, x) => ((x, y), int.Parse(c.ToString())))).ToDictionary(x => x.Item1, x => x.Item2);

var x = GetAllPathsThroughGrid(grid, 0, 0).Min();
Console.WriteLine(x);

static List<int> GetAllPathsThroughGrid(Dictionary<(int, int), int> grid, int x, int y)
{
    var result = new List<int>();
    if (x < 79)
        result.AddRange(GetAllPathsThroughGrid(grid, x + 1, y));
    if (y < 79)
        result.AddRange(GetAllPathsThroughGrid(grid, x, y + 1));
    if (x == 79 && y == 79)
        result.Add(grid[(x, y)]);
    return result;
}