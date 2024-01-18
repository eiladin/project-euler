using System.Numerics;
namespace Euler;

public class Utils
{
    public static bool[] Primes(int n)
    {
        bool[] a = new bool[n + 1];
        for (int i = 0; i < n; i++)
            a[i] = true;
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

    public static IEnumerable<int> GetDigits(string s)
    {
        foreach (char c in s)
            yield return int.Parse(c.ToString());
    }

    public static IEnumerable<int> GetDigits(int n) => GetDigits(n.ToString());
    public static IEnumerable<int> GetDigits(long n) => GetDigits(n.ToString());
    public static IEnumerable<int> GetDigits(BigInteger n) => GetDigits(n.ToString());
}