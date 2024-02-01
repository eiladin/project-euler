using System.Numerics;
using Euler;

var target = 2000;
var count = 2;
var result = BigInteger.Zero;
for (int ring = 2; result == 0; ring++)
{
    if (new[] { ring * 6 - 1, ring * 6 + 1, ring * 12 + 5 }.All(Primes.IsPrime))
    {
        count += 1;
        if (count == target)
        {
            result = (BigInteger)ring * (ring - 1) * 3 + 2;
            break;
        }
    }
    if (new[] { ring * 6 - 1, ring * 6 + 5, ring * 12 - 7 }.All(Primes.IsPrime))
    {
        count += 1;
        if (count == target)
        {
            result = (BigInteger)ring * (ring + 1) * 3 + 1;
            break;
        }
    }
}

Console.WriteLine(result);