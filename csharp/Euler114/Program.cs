Dictionary<int, long> memo = [];
var totalLen = 50;

var blockSizes = new List<int> { 1 };
for (int i = 3; i <= totalLen; i++)
    blockSizes.Add(i);
var result = Divide(totalLen, [.. blockSizes]).Sum();
Console.WriteLine(result);

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