using System;
using System.Numerics;

BigInteger x = 0, y = 0;
BigInteger max = 0;
var maxD = 0;
for (var d = 2; d <= 1000; d++)
{
    if (Math.Sqrt(d) % 1 == 0)
        continue;
    SolvePell(d, ref x, ref y);
    if (x > max)
    {
        max = x;
        maxD = d;
    }
}
Console.WriteLine(maxD);

static void Move(ref BigInteger a, ref BigInteger b, int c)
{
    (a, b) = (b, b * c + a);
}

static void SolvePell(int n, ref BigInteger a, ref BigInteger b)
{
    var x = (int)Math.Sqrt(n);
    var y = x;
    var z = 1;
    var r = x << 1;
    var (e1, e2, f1, f2) = ((BigInteger)1, (BigInteger)0, (BigInteger)0, (BigInteger)1);
    while (true)
    {
        y = r * z - y;
        z = (n - y * y) / z;
        r = (x + y) / z;
        Move(ref e1, ref e2, r);
        Move(ref f1, ref f2, r);
        a = f2;
        b = e2;
        Move(ref b, ref a, x);
        if (a * a - n * b * b == 1)
            return;
    }
}