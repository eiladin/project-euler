
using Euler;

int limit = 1_000_000;
var divisorsSum = Enumerable.Range(0, limit + 1).Select(i => Numerics.GetProperDivisors(i).Sum()).ToArray();

HashSet<int> longestChain = [];
for (int i = 1; i <= limit; i++)
{
    int currentNumber = i;
    HashSet<int> chain = [];
    int chainLength = 0;

    while (!chain.Contains(currentNumber) && currentNumber <= limit)
    {
        chain.Add(currentNumber);
        currentNumber = divisorsSum[currentNumber];
        chainLength++;
    }

    if (currentNumber == i && chainLength > longestChain.Count)
        longestChain = chain;
}

Console.WriteLine(longestChain.Min());
