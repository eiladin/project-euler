using System.Numerics;

BigInteger result = 0;
for (int k = 0; k < 16; k++)
    result += 15 * BigInteger.Pow(16, k)
            - 15 * BigInteger.Pow(15, k)
            - 2 * 14 * BigInteger.Pow(15, k)
            + 13 * BigInteger.Pow(14, k)
            + 2 * 14 * BigInteger.Pow(14, k)
            - 13 * BigInteger.Pow(13, k);
Console.WriteLine(result.ToString("X"));
