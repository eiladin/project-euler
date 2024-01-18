using System.Numerics;
using Euler;

var e = new List<int>() { 2 };
var i = 1;

while (e.Count < 100)
{
    e.Add(1);
    e.Add(2 * i);
    e.Add(1);
    i++;
}

e = e.Reverse<int>().ToList();
BigInteger numerator = 1;
BigInteger denominator = e.First();

for (var x = 1; x < 100; x++)
{
    var temp = numerator;
    numerator = denominator;
    denominator = e[x] * denominator + temp;
}

var result = Numerics.GetDigits(denominator).Sum();
Console.WriteLine(result);
