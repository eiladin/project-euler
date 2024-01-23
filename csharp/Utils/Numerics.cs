using System.Net.NetworkInformation;
using System.Numerics;
namespace Euler;

public class Numerics
{
    public static IEnumerable<int> GetDigits(string s)
    {
        foreach (char c in s)
            yield return int.Parse(c.ToString());
    }

    public static IEnumerable<int> GetDigits(int n) => GetDigits(n.ToString());
    public static IEnumerable<int> GetDigits(long n) => GetDigits(n.ToString());
    public static IEnumerable<int> GetDigits(BigInteger n) => GetDigits(n.ToString());
    public static long Factorial(long n) => n == 0 ? 1 : n * Factorial(n - 1);
    public static BigInteger Factorial(BigInteger n) => n == 0 ? 1 : n * Factorial(n - 1);

    public static long GetTriangle(long n) => GetSidedNumber(3, n);
    public static long GetPentagonal(long n) => GetSidedNumber(5, n);
    public static long GetHexagonal(long n) => GetSidedNumber(6, n);
    public static long GetSeptagonal(long n) => GetSidedNumber(7, n);
    public static long GetOctagonal(long n) => GetSidedNumber(8, n);
    public static long GetSidedNumber(int sides, long n) => n * ((sides - 2) * n - (sides - 4)) / 2;

    public static bool IsPentagonal(long num)
    {
        var result = (Math.Sqrt(24 * num + 1) + 1) / 6;
        return result == (int)result;
    }

    public static int EulerTotient(int n)
    {
        int result = n;
        for (int p = 2; p * p <= n; p++)
            if (n % p == 0)
            {
                while (n % p == 0)
                    n /= p;
                result -= result / p;
            }

        if (n > 1)
            result -= result / n;

        return result;
    }

    public static (int Num, int Denom) ReduceFraction(int numerator, int denominator)
    {
        int gcd = 1;
        for (int i = 1; i <= numerator && i <= denominator; i++)
            if (numerator % i == 0 && denominator % i == 0)
                gcd = i;
        return (numerator / gcd, denominator / gcd);
    }

    public static int Lcm(int a, int b) => a * b / Gcd(a, b);
    public static long Lcm(long a, long b) => a * b / Gcd(a, b);
    public static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
    public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
    public static bool IsCoprime(int a, int b) => Gcd(a, b) == 1;

    public static IEnumerable<int> GetFactors(int num)
    {
        for (int i = 2; i * i <= num; i++)
            if (num % i == 0)
            {
                yield return i;
                if (i * i != num)
                    yield return num / i;
            }
    }

    public static IEnumerable<int> GetProperDivisors(int num)
    {
        yield return 1;
        foreach (var i in GetFactors(num).Where(n => n < num))
            yield return i;
    }
}