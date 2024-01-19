using System.Numerics;
using Euler;

int number = 1000000;
BigInteger sum = 1;

var tots = GenerateTotients(number);

foreach (var tot in tots)
    sum += tot.Value;

Console.WriteLine(sum - 2);

static Dictionary<int, int> GenerateTotients(int n)
{
    var totients = new Dictionary<int, int> { { 0, 0 } };
    List<List<int>> primeFactors = GeneratePrimeFactors(n);
    for (int i = 1; i < primeFactors.Count; i++)
    {
        double totient = i;
        foreach (int j in primeFactors[i])
            totient *= 1 - 1 / (double)j;
        totients.Add(i, (int)totient);
    }
    return totients;
}

static List<List<int>> GeneratePrimeFactors(int n)
{
    var primes = Primes.Get(n);
    var primeFactors = new List<List<int>>
    {
        new() { 0 }
    };
    for (int i = 1; i <= n; i++)
        primeFactors.Add([]);
    if (n == 1) return primeFactors;
    foreach (int i in primes.Select(v => (int)v))
        for (int j = i; j <= n; j += i)
            primeFactors[j].Add(i);
    return primeFactors;
}
