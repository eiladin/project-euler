using System.Collections;

BitArray primes = Primes(20);
List<string> pandigitalNumbers = Permutations("0123456789");
var result = pandigitalNumbers.Where(x => IsSpecial(primes, x)).Sum(x => long.Parse(x));
Console.WriteLine(result);

static bool IsSpecial(BitArray primes, string number)
{
    var nextPrime = 2;
    for (var i = 1; i < number.Length - 2; i++)
    {
        var n = int.Parse(number[i..(i + 3)]);
        if (n % nextPrime == 0)
            nextPrime = FindNextPrime(primes, nextPrime);
        else
            return false;
    }
    return true;

}

static int FindNextPrime(BitArray primes, int lastPrime)
{
    for (var i = lastPrime + 1; i < primes.Length; i++)
        if (primes[i])
            return i;
    return -1;
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

static List<string> Permutations(string s)
{
    List<string> permutations = [];
    if (s.Length == 1)
    {
        permutations.Add(s);
        return permutations;
    }
    foreach (string subPermutation in Permutations(s[1..]))
        for (int i = 0; i <= subPermutation.Length; i++)
            permutations.Add(subPermutation[..i] + s[0] + subPermutation[i..]);
    return permutations;
}