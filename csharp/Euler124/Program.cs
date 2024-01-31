using Euler;

var result = Enumerable.Range(1, 100_000).Select(n => (n: (long)n, rad: Radical(n))).OrderBy(p => p.rad).ThenBy(p => p.n).Skip(9999).First().n;
Console.WriteLine(result);

static long Radical(long n) => Numerics.GetPrimeFactors(n).Distinct().Aggregate(1L, (acc, f) => acc * f);