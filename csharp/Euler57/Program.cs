using System.Numerics;

BigInteger numerator = 1;
BigInteger denominator = 1;
var count = 0;
for (var i = 1; i <= 1000; i++)
{
    var a = numerator;
    var b = denominator;
    numerator = 2 * b + a;
    denominator += a;
    if (numerator.ToString().Length - denominator.ToString().Length > 0)
        count++;
}
Console.WriteLine(count);
