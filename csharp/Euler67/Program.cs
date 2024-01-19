var triangle = File.ReadAllLines("input.txt")
    .Select(line => line.Split(' ').Select(int.Parse).ToArray())
    .ToArray();

for (var i = triangle.Length - 1; i > 0; i--)
    for (var j = 0; j < triangle[i].Length - 1; j++)
        triangle[i - 1][j] += Math.Max(triangle[i][j], triangle[i][j + 1]);

Console.WriteLine(triangle[0][0]);