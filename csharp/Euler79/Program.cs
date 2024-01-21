var attempts = File.ReadAllLines("input.txt");
var digits = attempts.SelectMany(x => x).Distinct().ToArray();
var graph = new Dictionary<char, HashSet<char>>();
foreach (var digit in digits)
    graph[digit] = [];

foreach (var attempt in attempts)
{
    graph[attempt[0]].Add(attempt[1]);
    graph[attempt[0]].Add(attempt[2]);
    graph[attempt[1]].Add(attempt[2]);
}
var result = string.Join("", graph.Keys.OrderByDescending(x => graph[x].Count).ToArray());
Console.WriteLine(result);