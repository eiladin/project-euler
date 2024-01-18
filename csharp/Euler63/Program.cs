using System.Numerics;

List<BigInteger> list = [];
for (BigInteger num = 1; num < 10; num++)
{
    for (int power = 1; power <= 25; power++)
    {
        BigInteger result = BigInteger.Pow(num, power);
        var len = result.ToString().Length;
        if (len > power)
            break;
        if (len == power)
            list.Add(result);
    }
}
Console.WriteLine(list.Count);