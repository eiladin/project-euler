using Euler;

var count = 0;
for (int d = 5; d <= 12000; d++)
{
    for (int n = d / 3 + 1; n < d / 2 + 1; n++)
    {
        if (Numerics.Gcd(n, d) == 1)
            count++;
    }
}

Console.WriteLine(count);