using Euler;

var prime = Primes.Sieve(1000000);

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