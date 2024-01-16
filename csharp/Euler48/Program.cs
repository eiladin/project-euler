using System.Numerics;

BigInteger sum = 0;

for (BigInteger i = 1; i <= 1000; i++)
    sum += BigInteger.Pow(i, (int)i);

Console.WriteLine(sum.ToString()[^10..]);