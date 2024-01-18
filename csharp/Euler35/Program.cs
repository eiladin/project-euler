using Euler;

var prime = Primes.Sieve(1_000_000);

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