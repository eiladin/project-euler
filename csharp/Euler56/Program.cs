
using System.Numerics;

var max = Enumerable.Range(1, 100)
                    .SelectMany(a => Enumerable.Range(1, 100).Select(b => BigInteger.Pow(a, b).Digits().Sum()))
                    .Max();

Console.WriteLine(max);

static class Extensions
{
    static public IEnumerable<int> Digits(this BigInteger n)
    {
        while (n > 0)
        {
            yield return (int)(n % 10);
            n /= 10;
        }
    }
}