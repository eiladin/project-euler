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
}