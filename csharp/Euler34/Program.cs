using Euler;

long result = 0;

for (var i = 3; i <= 1_000_000; i++)
{
    var sumOfDigitFactorial = Numerics.GetDigits(i).Sum(n => Numerics.Factorial(n));
    if (sumOfDigitFactorial == i)
        result += i;
}

Console.WriteLine(result);