using System.Collections;

var primes = Primes(100000);

for (var i = 1000; i < 10000; i++)
{
    if (!primes[i])
        continue;

    var permutations = Permutations(i.ToString());
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

static List<string> Permutations(string num)
{
    var permutations = new List<string>();
    if (num.Length == 1)
    {
        permutations.Add(num);
        return permutations;
    }

    for (var i = 0; i < num.Length; i++)
    {
        var first = num[i];
        var rest = num.Remove(i, 1);
        var subPermutations = Permutations(rest);
        foreach (var subPermutation in subPermutations)
        {
            permutations.Add(first + subPermutation);
        }
    }

    return permutations;
}

static BitArray Primes(int n)
{
    BitArray a = new(n + 1, true);
    int limit = (int)Math.Sqrt(n);
    a[0] = false;
    a[1] = false;
    for (int i = 4; i <= n; i += 2)
        a[i] = false;
    for (int i = 3; i <= limit; i += 2)
    {
        if (a[i])
        {
            int step = i * 2;
            for (int j = i * i; j <= n; j += step)
                a[j] = false;
        }
    }
    return a;
}