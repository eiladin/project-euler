static bool IsPrime(int n)
{
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
            return false;
    }
    return true;
}

var result = Enumerable.Range(2, int.MaxValue / 2)
    .Where(IsPrime)
    .Skip(10000)
    .First();

Console.WriteLine(result);