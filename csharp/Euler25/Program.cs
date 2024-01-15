using System.Numerics;

Console.WriteLine(Fibonacci().TakeWhile(f => f.ToString().Length < 1000).Count());

static IEnumerable<BigInteger> Fibonacci()
{
    BigInteger a = 0;
    BigInteger b = 1;
    while (true)
    {
        yield return a;
        yield return b;
        a += b;
        b += a;
    }
}