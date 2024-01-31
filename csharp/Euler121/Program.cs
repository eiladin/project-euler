using System.Numerics;
using Euler;

var turns = 15;
var ways = new BigInteger[turns + 1][];
ways[0] = [1];
for (int i = 1; i <= turns; i++)
{
    ways[i] = new BigInteger[i + 1];
    for (int j = 0; j <= i; j++)
    {
        var temp = BigInteger.Zero;
        if (j < i)
            temp = ways[i - 1][j] * i;
        if (j > 0)
            temp += ways[i - 1][j - 1];
        ways[i][j] = temp;
    }
}

var numer = BigInteger.Zero;
for (int i = turns / 2 + 1; i <= turns; i++)
    numer += ways[turns][i];
var denom = Numerics.Factorial(new BigInteger(turns + 1));
Console.WriteLine(denom / numer);