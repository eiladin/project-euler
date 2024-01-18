using Euler;

var primes = Primes.Sieve(1_000_000_000);

var max = Enumerable.Range(1, 1_000_000_000)
    .AsParallel()
    .Where(x => primes[x] && IsPandigital(x.ToString()))
    .Max();

Console.WriteLine(max);

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