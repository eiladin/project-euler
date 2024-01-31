using Euler;

var primeSieve = Primes.Sieve(1_000_000);
var primes = primeSieve.Select((n, idx) => (n, idx)).Where(n => n.n).Select(n => (long)n.idx).ToList();
var n = 7037;

while (true)
{
    var r = 2 * n * primes[n - 1];
    if (r > 10_000_000_000)
        break;
    n += 2;
}
Console.WriteLine(n);