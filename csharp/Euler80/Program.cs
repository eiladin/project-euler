using System.Numerics;
using Euler;

var total = 0;

for (var i = 2; i < 100; i++)
{
    if (IsPerfectSquare(i))
        continue;

    var sqrt = CalculateSquareRoot(i, 100);
    var sum = Numerics.GetDigits(sqrt).Sum();
    total += sum;
}

Console.WriteLine(total);

static bool IsPerfectSquare(int n)
{
    var sqrt = (int)Math.Sqrt(n);
    return sqrt * sqrt == n;
}

static string CalculateSquareRoot(int n, int precision)
{
    BigInteger a = 5 * n;
    BigInteger b = 5;

    while (b.ToString().Length < precision + 2)
    {
        if (a >= b)
        {
            a -= b;
            b += 10;
        }
        else
        {
            a *= 100;
            b = (b - b % 10) * 10 + b % 10;
        }
    }

    return b.ToString()[..101].ToString();
}
