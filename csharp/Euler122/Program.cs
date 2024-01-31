int limit = 200;
int[] minOperations;
int numUnknown;

minOperations = Enumerable.Range(0, limit + 1).Select(i => -1).ToArray();
minOperations[0] = 0;
minOperations[1] = 0;
numUnknown = limit - 1;

for (int ops = 1; numUnknown > 0; ops++)
{
    var chain = new IntStack(ops + 1);
    chain.Push(1);
    ExploreChains(chain, ops);
}
var sum = minOperations.Sum();
Console.WriteLine(sum);


void ExploreChains(IntStack chain, int maxOps)
{
    if (chain.Count > maxOps || numUnknown == 0)
        return;

    var max = chain.Values[chain.Count - 1];
    for (var i = chain.Count - 1; i >= 0; i--)
    {
        for (var j = i; j >= 0; j--)
        {
            var x = chain.Values[i] + chain.Values[j];
            if (x <= max)
                break;
            if (x <= limit)
            {
                chain.Push(x);
                if (minOperations[x] == -1)
                {
                    minOperations[x] = chain.Count - 1;
                    numUnknown--;
                }
                ExploreChains(chain, maxOps);
                chain.Pop();
            }
        }
    }
}

internal class IntStack(int capacity)
{
    public int[] Values = new int[capacity];
    public int Count = 0;

    public void Push(int x)
    {
        if (Count >= Values.Length)
            throw new IndexOutOfRangeException();
        Values[Count] = x;
        Count++;
    }

    public int Pop()
    {
        if (Count <= 0)
            throw new IndexOutOfRangeException();
        Count--;
        return Values[Count];
    }
}