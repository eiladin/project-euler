using Euler;

var primes = Primes.Sieve(20);
List<string> pandigitalNumbers = Collections.GetPermutations("0123456789");
var result = pandigitalNumbers.Where(x => IsSpecial(primes, x)).Sum(x => long.Parse(x));
Console.WriteLine(result);

static bool IsSpecial(bool[] primes, string number)
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

static int FindNextPrime(bool[] primes, int lastPrime)
{
    for (var i = lastPrime + 1; i < primes.Length; i++)
        if (primes[i])
            return i;
    return -1;
}