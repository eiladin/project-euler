using Euler;

var primes = Primes.Sieve(20_000);

List<int> results = [91, 259, 451, 481, 703];

for (var i = 704; results.Count < 25; i++)
{
    if (primes[i])
        continue;

    var repunit = Numerics.Repunit(i);
    if (repunit > 1 && (i - 1) % repunit == 0)
        results.Add(i);
}
Console.WriteLine(results.Sum());

