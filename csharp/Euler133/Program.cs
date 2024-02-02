using System.Numerics;
using Euler;

var result = 0L;
var primes = Primes.Get(100_000);
BigInteger k = BigInteger.Pow(10, 16);

for (var i = 0; i < primes.Count; i++)
{
    if (BigInteger.ModPow(10, k, 9 * primes[i]) != 1)
        result += primes[i];
}
Console.WriteLine(result);