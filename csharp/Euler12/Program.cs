using Euler;

Console.WriteLine(GetTriangleNumbers().First(x => GetDivisors(x).Count > 500));

static IEnumerable<long> GetTriangleNumbers()
{
    for (long i = 1; i <= long.MaxValue; i++)
        yield return Numerics.GetTriangle(i);
}

static List<long> GetDivisors(long number)
{
    List<long> divisors = [];
    for (int i = 1; i <= Math.Sqrt(number) - 1; i++)
    {
        if (number % i == 0)
        {
            divisors.Add(i);
            divisors.Add(number / i);
        }
    }
    return divisors;
}

