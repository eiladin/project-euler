
using Euler;

List<(int Num, int Denom)> fractions = [];
for (var num = 11; num <= 99; num++)
{
    for (var den = num + 1; den <= 99; den++)
    {
        if (den.ToString()[1] != num.ToString()[0] && den.ToString()[0] != num.ToString()[1])
            continue;
        var (num1, den1) = Numerics.ReduceFraction(num, den);
        var (num2, den2) = Numerics.ReduceFraction(num / 10, den % 10);
        if (num1 == num2 && den1 == den2)
            fractions.Add((num, den));
    }
}

var (resultNum, resultDenom) = fractions.Aggregate((Num: 1, Denom: 1), (a, b) => (a.Num * b.Num, a.Denom * b.Denom));
Console.WriteLine(Numerics.ReduceFraction(resultNum, resultDenom).Denom);
