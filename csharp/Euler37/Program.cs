using System.Collections;

var prime = Primes(1000000);

var sum = 0;

for (int i = 11; i < prime.Length; i++)
{
    if (!prime[i])
        continue;

    if (TruncateLeft(i).All(x => prime[x]) && TruncateRight(i).All(x => prime[x]))
        sum += i;
}

Console.WriteLine(sum);

static IEnumerable<int> TruncateLeft(int n)
{
    var s = n.ToString();
    for (int i = 1; i < s.Length; i++)
        yield return int.Parse(s[i..]);
}

static IEnumerable<int> TruncateRight(int n)
{
    var s = n.ToString();
    for (int i = 1; i < s.Length; i++)
        yield return int.Parse(s[..^i]);
}

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