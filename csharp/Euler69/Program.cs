double maxRatio = 0;
int maxN = 0;

for (var i = 2; i <= 1000000; i++)
{
    var totient = EulerTotient(i);
    var ratio = (double)i / totient;
    if (ratio > maxRatio)
    {
        maxRatio = ratio;
        maxN = i;
    }
}

Console.WriteLine(maxN);


static int EulerTotient(int n)
{
    int result = n;
    for (int p = 2; p * p <= n; p++)
        if (n % p == 0)
        {
            while (n % p == 0)
                n /= p;
            result -= result / p;
        }

    if (n > 1)
        result -= result / n;

    return result;
}
