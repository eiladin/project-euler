var abundantNums = Enumerable.Range(12, 1000000).Where(i => getFactors(i).Sum() > i).ToList();

var dict = new Dictionary<int, bool>();
for (int i = 0; i < 28124; ++i)
    dict[i] = false;

for (int i = 0; i < abundantNums.Count; ++i)
    for (int j = i; j < abundantNums.Count; ++j)
    {
        var sum = abundantNums[i] + abundantNums[j];
        if (sum < 28124)
            dict[sum] = true;
        else
            break;
    }


Console.WriteLine(dict.Where(kvp => kvp.Value == false).Sum(kvp => kvp.Key));

static IEnumerable<int> getFactors(int num)
{
    yield return 1;
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            yield return i;
            if (num / i != i)
                yield return num / i;
        }
    }
}