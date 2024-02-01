using Euler;

var result = Enumerable.Range(1, 100_000).Select(n => (n: (long)n, rad: Numerics.Radical(n))).OrderBy(p => p.rad).ThenBy(p => p.n).Skip(9999).First().n;
Console.WriteLine(result);