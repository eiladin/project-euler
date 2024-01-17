using System.Numerics;

var count = Enumerable.Range(1, 100)
    .SelectMany(n => Enumerable.Range(1, 100)
        .Select(r => Factorial(n) / (Factorial(r) * Factorial(n - r))))
    .Count(x => x > 1_000_000);

Console.WriteLine(count);

static BigInteger Factorial(int n)
{
    if (n == 0)
        return 1;
    var result = new BigInteger(1);
    for (var i = 1; i <= n; i++)
        result *= i;
    return result;
}