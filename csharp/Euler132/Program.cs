using System.Numerics;
using Euler;

var result = 0L;
var count = 0;
var primes = Primes.Get(200_000);
var k = (int)Math.Pow(10, 9);

for (var i = 0; count < 40; i++)
{
    if (BigInteger.ModPow(10, k, 9 * primes[i]) == 1)
    {
        result += primes[i];
        count++;
    }
}

Console.WriteLine(result);