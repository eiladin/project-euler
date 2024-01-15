Dictionary<ulong, int> items = [];

for (ulong i = 1; i <= 1000000; i++)
    items[i] = Collatz(i).ToList().Count;

var ordered = items.OrderByDescending(x => x.Value).ToList();
Console.WriteLine(items.MaxBy(x => x.Value).Key);

static IEnumerable<ulong> Collatz(ulong n)
{
    while (n > 1)
    {
        yield return n;
        n = n % 2 == 0 ? n / 2 : 3 * n + 1;
    }
    yield return 1;
}
