using Euler;

var primes = Primes.Sieve(100000);

for (var i = 1000; i < 10000; i++)
{
    if (!primes[i])
        continue;

    var permutations = Collections.GetPermutations(i.ToString());
    var primePermutations = permutations.Where(p => primes[int.Parse(p)] && !p.StartsWith('0')).Distinct().Select(p => int.Parse(p)).ToList();
    if (primePermutations.Count < 3 || primePermutations.Contains(1487))
        continue;

    primePermutations.Sort();
    for (var j = 0; j < primePermutations.Count - 2; j++)
    {
        var first = primePermutations[j];
        var diff = primePermutations[j + 1] - first;
        if (primePermutations.Contains(first + diff) && primePermutations.Contains(first + diff + diff))
        {
            Console.WriteLine($"{first}{first + diff}{first + diff + diff}");
            return;
        }
    }
}