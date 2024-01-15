using System.Numerics;

BigInteger num = 1;
int digits = 100;
for (var i = digits; i > 0; i--)
    num *= i;

var result = num.ToString().Select(c => int.Parse(c.ToString())).Sum();
Console.WriteLine(result);
