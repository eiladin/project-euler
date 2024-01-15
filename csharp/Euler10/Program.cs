static IEnumerable<long> GetPrimes(long max)
{
    var seiveMax = (max - 1) / 2;
    var seive = new Dictionary<long, bool>();
    for (int i = 1; i < seiveMax; i++)
        seive[i] = false;
    var seiveSqrt = (int)((Math.Sqrt(max) - 1) / 2);
    for (int i = 1; i <= seiveSqrt; i++)
        if (!seive[i])
            for (int j = i * 2 * (i + 1); j <= seiveMax; j += 2 * i + 1)
                seive[j] = true;
    return seive.Where(x => !x.Value).Select(x => 2 * x.Key + 1).Concat([2L]);
}

var result = GetPrimes(2_000_000).Where(x => x > 1);
Console.WriteLine(result.Sum());