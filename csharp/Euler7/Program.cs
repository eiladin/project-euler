using Euler;

var result = Enumerable.Range(2, int.MaxValue / 2)
    .Where(Primes.IsPrime)
    .Skip(10000)
    .First();

Console.WriteLine(result);