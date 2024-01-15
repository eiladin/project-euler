Console.WriteLine(Primes(1000).Where(n => n >= 7).MaxBy(CycleLength));

static IEnumerable<int> Primes(int limit)
{
    for (int number = 2; number < limit; number++)
    {
        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                isPrime = false;
                break;
            }
        }
        if (isPrime)
            yield return number;
    }
}


static int CycleLength(int b)
{
    Dictionary<int, int> hash = [];
    int a = 1;
    int t = 0;
    while (!hash.ContainsKey(a))
    {
        hash[a] = t;
        a = a % b * 10;
        t++;
    }
    return t - hash[a];
}