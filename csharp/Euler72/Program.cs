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
    var primeFactors = Primes.GetPrimeFactors(n);
    foreach (var i in primeFactors.Keys.Skip(1))
    {
        double totient = i;
        foreach (int j in primeFactors[i])
            totient *= 1 - 1 / (double)j;
        totients.Add(i, (int)totient);
    }
    return totients;
}
