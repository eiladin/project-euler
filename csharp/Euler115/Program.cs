Dictionary<int, long> memo = [];

var m = 50;
var count = 0L;
int i;
for (i = m; count < 1_000_000; i++)
{
    var blockSizes = new List<int> { 1 };
    Enumerable.Range(m, i - m).ToList().ForEach(blockSizes.Add);
    memo.Clear();
    count = Divide(i, [.. blockSizes]).Sum();
}
Console.WriteLine(i);


IEnumerable<long> Divide(int totalLen, int[] blockSize)
{
    if (totalLen < 0)
        yield return 0;
    else if (totalLen == 0)
        yield return 1;
    else
    {
        if (memo.TryGetValue(totalLen, out long value))
            yield return value;
        else
        {
            foreach (var block in blockSize)
            {
                if (block <= totalLen)
                {
                    var newSize = totalLen - block;
                    if (block != 1 && newSize > 0)
                        newSize -= 1;
                    var s = Divide(newSize, blockSize).Sum();
                    memo[newSize] = s;
                    yield return s;
                }
            }
        }
    }
}