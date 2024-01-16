
List<(int Num, int Denom)> fractions = [];
for (var num = 11; num <= 99; num++)
{
    for (var den = num + 1; den <= 99; den++)
    {
        if (den.ToString()[1] != num.ToString()[0] && den.ToString()[0] != num.ToString()[1])
            continue;
        var (num1, den1) = SimplifyFraction(num, den);
        var (num2, den2) = SimplifyFraction(num / 10, den % 10);
        if (num1 == num2 && den1 == den2)
            fractions.Add((num, den));
    }
}

var (resultNum, resultDenom) = fractions.Aggregate((Num: 1, Denom: 1), (a, b) => (a.Num * b.Num, a.Denom * b.Denom));
Console.WriteLine(SimplifyFraction(resultNum, resultDenom).Denom);

static (int Num, int Denom) SimplifyFraction(int numerator, int denominator)
{
    int gcd = 1;
    for (int i = 1; i <= numerator && i <= denominator; i++)
        if (numerator % i == 0 && denominator % i == 0)
            gcd = i;
    return (numerator / gcd, denominator / gcd);
}