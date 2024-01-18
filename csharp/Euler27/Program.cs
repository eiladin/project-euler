using Euler;

var primes = Primes.Sieve(100000);

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