Console.WriteLine(LatticePaths.Progress(0, 0));

internal static class LatticePaths
{
    const int gridSize = 20;

    static Func<A1, A2, R> Memoize<A1, A2, R>(this Func<A1, A2, R> func)
    {
        var dictionary = new Dictionary<string, R>();
        return (A1 a1, A2 a2) =>
        {
            string key = a1 + "x" + a2;
            if (!dictionary.TryGetValue(key, out R? res))
            {
                res = func(a1, a2);
                dictionary.Add(key, res);
            }
            return res;
        };
    }

    static long CalcSurface(long x, long y) => (gridSize - x) * (gridSize - y);

    public static readonly Func<long, long, long> Progress = ((Func<long, long, long>)((long x, long y) =>
    {
        long surface = CalcSurface(x, y);
        long i = 0;

        if (surface == 0)
            return 1;

        if (x < gridSize)
            i += Progress!(x + 1, y);
        if (y < gridSize)
            i += Progress!(x, y + 1);
        return i;
    })).Memoize();
}