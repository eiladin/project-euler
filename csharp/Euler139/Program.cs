using Euler;

var limit = 100_000_000;

var result = 0;
for (var m = 2; m < Math.Sqrt(limit / 2); m++)
{
    for (var n = 1; n < m; n++)
    {
        if ((m - n) % 2 == 1 && Numerics.Gcd(m, n) == 1)
        {
            var a = m * m - n * n;
            var b = 2 * m * n;
            var c = m * m + n * n;
            if (c % (b - a) == 0)
                result += limit / (a + b + c);
        }
    }
}
Console.WriteLine(result);