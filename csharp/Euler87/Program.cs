using Euler;

var primes = Primes.Get((int)Math.Sqrt(50_000_000));
var result = Enumerable.Range(0, primes.Count)
                       .SelectMany(a => Enumerable.Range(0, primes.Count)
                            .SelectMany(b => Enumerable.Range(0, primes.Count)
                                    .Select(c => primes[a] * primes[a] + primes[b] * primes[b] * primes[b] + primes[c] * primes[c] * primes[c] * primes[c])
                                    .TakeWhile(x => x < 50_000_000).ToList()));

Console.WriteLine(result.Distinct().Count());