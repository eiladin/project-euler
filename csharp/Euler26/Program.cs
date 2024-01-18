using Euler;

Console.WriteLine(Primes.Get(1000).Where(n => n >= 7).MaxBy(CycleLength));

static long CycleLength(long b)
{
    Dictionary<long, long> hash = [];
    long a = 1;
    long t = 0;
    while (!hash.ContainsKey(a))
    {
        hash[a] = t;
        a = a % b * 10;
        t++;
    }
    return t - hash[a];
}