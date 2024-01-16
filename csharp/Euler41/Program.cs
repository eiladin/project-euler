using System.Collections;

var primes = Primes(1_000_000_000);

var max = Enumerable.Range(1, 1_000_000_000)
    .AsParallel()
    .Where(x => primes[x] && IsPandigital(x.ToString()))
    .Max();

Console.WriteLine(max);

static BitArray Primes(int n)
{
    BitArray a = new(n + 1, true);
    int limit = (int)Math.Sqrt(n);
    a[0] = false;
    a[1] = false;
    for (int i = 4; i <= n; i += 2)
        a[i] = false;
    for (int i = 3; i <= limit; i += 2)
    {
        if (a[i])
        {
            int step = i * 2;
            for (int j = i * i; j <= n; j += step)
                a[j] = false;
        }
    }
    return a;
}

static bool IsPandigital(string s)
{
    var digits = new int[10];
    foreach (var c in s)
        digits[c - '0']++;

    for (var i = 1; i <= s.Length; i++)
        if (digits[i] != 1)
            return false;
    return true;
}