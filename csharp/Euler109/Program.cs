
var points = Enumerable.Range(1, 20).SelectMany(i => new[] { i, i * 2, i * 3 }).Concat([25, 50]).ToList();
var doublePoints = Enumerable.Range(1, 20).Select(i => i * 2).Concat([50]).ToList();

var ways = new int[3, 101, points.Count];

for (int i = 0; i < 3; i++)
    for (int j = 0; j < 101; j++)
        for (int k = 0; k < points.Count; k++)
            ways[i, j, k] = -1;

int checkouts = 0;
for (int remainingPoints = 1; remainingPoints < 100; remainingPoints++)
    for (int throws = 0; throws < 3; throws++)
        foreach (var p in doublePoints)
            if (p <= remainingPoints)
                checkouts += CalcWays(throws, remainingPoints - p, points.Count - 1);

Console.WriteLine(checkouts);

int CalcWays(int throws, int total, int maxIndex)
{
    if (ways[throws, total, maxIndex] == -1)
    {
        if (throws == 0)
            ways[throws, total, maxIndex] = total == 0 ? 1 : 0;
        else
        {
            ways[throws, total, maxIndex] = 0;
            if (maxIndex > 0)
                ways[throws, total, maxIndex] += CalcWays(throws, total, maxIndex - 1);
            if (points[maxIndex] <= total)
                ways[throws, total, maxIndex] += CalcWays(throws - 1, total - points[maxIndex], maxIndex);
        }
    }
    return ways[throws, total, maxIndex];
}