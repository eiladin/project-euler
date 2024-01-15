var num = 600851475143;

Console.WriteLine(GetFactors(num).Max());

static IEnumerable<long> GetFactors(long num)
{
    long i = 2L;
    while (num > 1)
    {
        if (num % i == 0)
        {
            yield return i;
            num /= i;
        }
        else
            i++;
    }
}