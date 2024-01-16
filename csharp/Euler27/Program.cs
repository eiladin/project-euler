using System.Collections;

var primes = Primes(100000);

int max = int.MinValue;
int result = 0;
for (int a = -999; a < 1000; a++)
{
    for (int b = -1000; b <= 1000; b++)
    {
        int n = 0;
        while (primes[Math.Abs(n * n + a * n + b)])
            n++;
        if (n > max)
        {
            max = n;
            result = a * b;
        }
    }
}

Console.WriteLine(result);

static BitArray Primes(int n)
{
    BitArray a = new(n + 1, true);
    int limit = (int)Math.Sqrt(n);
    a[0] = false;
    a[1] = false;
    for (int i = 4; i <= n; i += 2)
        a[i] = false;
    for (int i = 3; i <= limit; i += 2)
    {
        if (a[i])
        {
            int step = i * 2;
            for (int j = i * i; j <= n; j += step)
                a[j] = false;
        }
    }
    return a;
}