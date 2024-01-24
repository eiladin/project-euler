var lines = File.ReadAllLines("input.txt");
var numbers = lines.Select(line => line.Split(',')).Select((pair, i) => new { Index = i + 1, Value = long.Parse(pair[1]) * Math.Log(long.Parse(pair[0])) });
var max = numbers.MaxBy(n => n.Value)!.Index;
Console.WriteLine(max);
