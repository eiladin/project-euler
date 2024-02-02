using Euler;

var limit = 1_000_100;
var primes = Primes.Get(limit);
var result = 0L;

for (int i = 2; primes[i] < 1_000_000; i++)
{
    var a1 = primes[i];
    var m1 = (long)Math.Pow(10, Math.Ceiling(Math.Log10(a1)));
    var m2 = primes[i + 1];
    var cr = a1 * m2 * Numerics.ModInverse(m2, m1) % (m1 * m2);
    result += cr;
}

Console.WriteLine(result);
