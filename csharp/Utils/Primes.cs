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
        if (n < 2)
            return false;
        if (n == 2)
            return true;
        if (n % 2 == 0)
            return false;
        int limit = (int)Math.Sqrt(n);
        for (var i = 3; i <= limit; i += 2)
            if (n % i == 0)
                return false;
        return true;
    }
}