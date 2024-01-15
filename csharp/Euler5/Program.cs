using System.Collections;

static IEnumerable<int> getPrimes(int n)
{
    BitArray a = new(n + 1, true);

    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (a[i])
            for (int j = i * i; j <= n; j += i)
                a[j] = false;
    }

    for (int i = 2; i <= n; i++)
        if (a[i])
            yield return i;
}

static IEnumerable<(int, int)> getUniqueDivisors(int n)
{
    int i = 2;
    while (n > 1)
    {
        if (n % i == 0)
        {
            n /= i;
            int count = 1;
            while (n % i == 0)
            {
                n /= i;
                count++;
            }
            yield return (i, count);
        }
        i++;
    }
}

var primes = getPrimes(20).ToArray();

int[] counts = new int[21];
for (int i = 2; i <= 20; i++)
    foreach (var (prime, count) in getUniqueDivisors(i))
        counts[prime] = Math.Max(counts[prime], count);

var result = 1;
for (int i = 0; i < primes.Length; i++)
    result *= (int)Math.Pow(primes[i], counts[primes[i]]);

Console.WriteLine(result);