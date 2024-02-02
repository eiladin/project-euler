using Euler;

int result = 0;
for (int i = 1; ; i++)
{
    var n = (i + 1) * (i + 1) * (i + 1) - i * i * i;
    if (n > 1_000_000)
        break;
    result += Primes.IsPrime(n) ? 1 : 0;
}
Console.WriteLine(result);
