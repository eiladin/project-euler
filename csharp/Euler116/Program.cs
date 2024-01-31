Dictionary<(int, int[]), long> memo = [];

var totalLen = 50;

var blockSizes = new[] { new[] { 1, 2 }, [1, 3], [1, 4] };
var result = 0L;
foreach (var blockSize in blockSizes)
{
    memo.Clear();
    result += Divide(totalLen, blockSize).Sum() - 1;
}
Console.WriteLine(result);

IEnumerable<long> Divide(int totalLen, int[] blockSize)
{
    if (totalLen < 0)
        yield return 0;
    else if (totalLen == 0)
        yield return 1;
    else
    {
        var key = (totalLen, blockSize);
        if (memo.TryGetValue(key, out long value))
            yield return value;
        else
        {
            foreach (var block in blockSize)
            {
                var s = Divide(totalLen - block, blockSize).Sum();
                memo[(totalLen - block, blockSize)] = s;
                yield return s;
            }
        }
    }
}