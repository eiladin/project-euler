using Euler;

var result = Primes.Get(2_000_000).Where(x => x > 1);
Console.WriteLine(result.Sum());