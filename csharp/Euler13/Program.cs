var lines = File.ReadAllLines("input.txt");
var result = lines.Select(x => long.Parse(x[..15])).Sum();
Console.WriteLine(result.ToString()[..10]);