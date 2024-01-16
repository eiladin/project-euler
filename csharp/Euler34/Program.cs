long result = 0;

for (var i = 3; i <= 1_000_000; i++)
{
    var sumOfDigitFactorial = GetDigits(i).Sum(n => Factorial(n));
    if (sumOfDigitFactorial == i)
        result += i;
}

Console.WriteLine(result);

static long Factorial(long n) => n == 0 ? 1 : n * Factorial(n - 1);

static IEnumerable<long> GetDigits(long n)
{
    while (n > 0)
    {
        yield return n % 10;
        n /= 10;
    }
}