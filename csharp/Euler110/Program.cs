ulong limit = 4_000_000;
int[] primes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37];
var numPrimes = primes.Length;

var primeExponents = new SortedDictionary<double, List<int>>
{
    { 1, new List<int>(new int[numPrimes]) }
};

var uniqueFactors = 0UL;
var value = 0.0;
while (uniqueFactors < limit)
{
    var current = primeExponents.First();
    value = current.Key;
    var exponents = current.Value;

    primeExponents.Remove(current.Key);

    uniqueFactors = 1;
    foreach (var x in exponents)
        uniqueFactors *= (ulong)(2 * x + 1);

    uniqueFactors++;
    uniqueFactors /= 2;

    if (uniqueFactors >= limit)
        break;

    for (var i = 0; i < exponents.Count; i++)
    {
        exponents[i]++;
        value *= primes[i];

        if (!primeExponents.ContainsKey(value))
            primeExponents[value] = [.. exponents];
    }
}

Console.WriteLine(value);