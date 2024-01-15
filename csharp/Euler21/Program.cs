var sum = 0;
Dictionary<int, int> divisorCounts = [];
for (var i = 1; i < 10000; i++)
    divisorCounts[i] = GetDivisors(i).Sum();

for (var i = 1; i < divisorCounts.Count; i++)
    if (divisorCounts[i] < 10000 && divisorCounts[i] > 0 && divisorCounts[divisorCounts[i]] == i && divisorCounts[i] != i)
        sum += i;

Console.WriteLine(sum);


static IEnumerable<int> GetDivisors(int number)
{
    for (int i = 1; i < number; i++)
        if (number % i == 0)
            yield return i;
}