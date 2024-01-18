using Euler;

List<int> primesSoFar = [2];
Dictionary<int, List<int>> edgeDic = new() { { 2, new List<int>() } };
int upperLim = int.MaxValue;
int min = int.MaxValue;

int lim = 3;
while (lim < upperLim)
{
    if (Primes.IsPrime(lim))
    {
        var neighbors = new List<int>();
        foreach (var prime in primesSoFar)
            if (GoodPair(lim, prime))
                neighbors.Add(prime);

        var (match, subset) = GetCompleteN(neighbors, edgeDic, 4);
        if (match)
        {
            subset.Add(lim);
            if (subset.Sum() < min)
            {
                min = subset.Sum();
                upperLim = min - 792;
            }
        }

        foreach (var goodprime in neighbors)
        {
            if (!edgeDic.TryGetValue(goodprime, out List<int>? value))
            {
                value = [];
                edgeDic[goodprime] = value;
            }

            value.Add(lim);
        }

        if (!edgeDic.ContainsKey(lim))
            edgeDic[lim] = [];
        edgeDic[lim] = neighbors;
        primesSoFar.Add(lim);
    }
    lim += 2;
}

Console.WriteLine(min);

static int AppendNumbers(int a, int b)
{
    int c = b;
    while (c > 0)
    {
        c /= 10;
        a *= 10;
    }
    return a + b;
}

static bool GoodPair(int a, int b)
{
    if (!Primes.IsPrime(AppendNumbers(a, b)))
        return false;
    return Primes.IsPrime(AppendNumbers(b, a));
}

static (bool, List<int>) GetCompleteN(List<int> nodes, Dictionary<int, List<int>> edges, int N)
{
    if (N == 1)
    {
        if (nodes.Count != 0)
            return (true, nodes.Take(1).ToList());
        return (false, new List<int>());
    }
    for (int i = 0; i < nodes.Count; i++)
    {
        var candidateSet = edges[nodes[i]].Where(node => nodes.Contains(node)).ToList();
        var (match, subset) = GetCompleteN(candidateSet, edges, N - 1);
        if (match)
        {
            var result = new List<int> { nodes[i] };
            result.AddRange(subset);
            return (true, result);
        }
    }
    return (false, new List<int>());
}
