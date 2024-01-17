var result = Enumerable.Range(1, 1000000).First(
    num => Enumerable.Range(2, 5).All(
        multiplier => GetDigits(num, multiplier).All(
            d => GetDigits(num, 1).Contains(d)
        )
    )
);
Console.WriteLine(result);

static IEnumerable<int> GetDigits(int number, int multiplier)
{
    number *= multiplier;
    while (number > 0)
    {
        yield return number % 10;
        number /= 10;
    }
}