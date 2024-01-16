var max = Enumerable.Range(1, 1000).Select(p => (p, GetSidesForPermimeter(p).Count())).OrderByDescending(x => x.Item2).First().p;
Console.WriteLine(max);

static IEnumerable<(int a, int b, int c)> GetSidesForPermimeter(int p)
{
    for (var a = 1; a < p; a++)
        for (var b = 1; b < p; b++)
        {
            var c = p - a - b;
            if (c > 0 && a * a + b * b == c * c)
                yield return (a, b, c);
        }
}