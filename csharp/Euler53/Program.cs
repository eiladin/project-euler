using System.Numerics;
using Euler;

var count = 0;
for (BigInteger n = 1; n <= 100; n++)
    for (BigInteger r = 1; r <= n; r++)
        if (Numerics.Factorial(n) / (Numerics.Factorial(r) * Numerics.Factorial(n - r)) > 1_000_000)
            count++;

Console.WriteLine(count);
