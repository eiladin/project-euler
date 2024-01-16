List<int> factors =
[
    GetDistinctPrimeFactorsCount(1),
    GetDistinctPrimeFactorsCount(2),
    GetDistinctPrimeFactorsCount(3),
    GetDistinctPrimeFactorsCount(4),
];
var result = 4;
while (factors.Skip(factors.Count - 4).Sum() != 16)
{
    factors.Add(GetDistinctPrimeFactorsCount(result));
    result++;
}
Console.WriteLine(result - 4);

static int GetDistinctPrimeFactorsCount(int number)
{
    var factors = new List<int>();
    var divisor = 2;

    while (number > 1)
    {
        while (number % divisor == 0)
        {
            factors.Add(divisor);
            number /= divisor;
        }

        divisor++;
    }

    return factors.Distinct().Count();
}