using System.Collections;

var prime = Primes(1_000_000);

var count = 0;

for (var i = 2; i < prime.Length; i++)
{
    if (!prime[i])
        continue;

    var rotations = Rotations(i);
    if (rotations.All(r => prime[r]))
        count++;
}

Console.WriteLine(count);

static IEnumerable<int> Rotations(int number)
{
    int digits = (int)Math.Log10(number);
    int pow10 = (int)Math.Pow(10, digits);
    for (int i = 0; i < digits; i++)
    {
        number = number / 10 + number % 10 * pow10;
        yield return number;
    }
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