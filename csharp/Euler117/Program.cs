Dictionary<(int, int[]), long> memo = [];

var totalLen = 50;

var blockSize = new[] { 1, 2, 3, 4 };
var result = 0L;
result = Divide(totalLen, blockSize).Sum();
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