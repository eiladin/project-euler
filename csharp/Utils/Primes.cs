using System.Numerics;

namespace Euler;

public class Primes
{
    public static bool[] Sieve(long n)
    {
        bool[] a = new bool[n + 1];
        for (long i = 0; i < n; i++)
            a[i] = true;
        long limit = (long)Math.Sqrt(n);
        a[0] = false;
        a[1] = false;
        for (long i = 4; i <= n; i += 2)
            a[i] = false;
        for (long i = 3; i <= limit; i += 2)
        {
            if (a[i])
            {
                long step = i * 2;
                for (long j = i * i; j <= n; j += step)
                    a[j] = false;
            }
        }
        return a;
    }

    public static IEnumerable<long> GetPrimesUpTo(long n)
    {
        var a = Sieve(n);
        for (long i = 0; i < (long)a.Length; i++)
            if (a[i])
                yield return i;
    }

    public static List<long> Get(long n)
    {
        var a = Sieve(n);
        var primes = new List<long>();
        for (long i = 0; i < (long)a.Length; i++)
            if (a[i])
                primes.Add(i);
        return primes;
    }

    public static bool IsPrime(int n)
    {
        if (n == 1)
            return false;
        if ((n & 1) == 0)
            return n == 2;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0)
                return false;
        return true;
    }

    public static bool IsPrime(long n)
    {
        if (n == 1)
            return false;
        if ((n & 1) == 0)
            return n == 2;
        for (int i = 3; i * i <= n; i += 2)
            if (n % i == 0)
                return false;
        return true;
    }

    public static Dictionary<int, List<int>> GetPrimeFactors(int n)
    {
        var primes = Get(n);
        var primeFactors = new Dictionary<int, List<int>>
        {
            { 0, new() { 0 } }
        };
        for (int i = 1; i <= n; i++)
            primeFactors.Add(i, []);
        if (n == 1)
            return primeFactors;
        foreach (int i in primes.Select(v => (int)v))
            for (int j = i; j <= n; j += i)
                primeFactors[j].Add(i);
        return primeFactors;
    }
}