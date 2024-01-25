
var targetSize = 7;

var maxsum = 1;
while (SpecialSumSet.MakeSet(targetSize, maxsum) == null)
    maxsum *= 2;

var i = maxsum / 4;
while (i > 0)
{
    maxsum -= i;
    if (SpecialSumSet.MakeSet(targetSize, maxsum) == null)
        maxsum += i;
    i /= 2;
}

var set = SpecialSumSet.MakeSet(targetSize, maxsum);
Console.WriteLine(set!.Values.Aggregate("", (s, i) => s + i));

internal class SpecialSumSet(List<int> values, List<bool> sumPossible, List<int> minimumSum, List<int> maximumSum)
{
    public List<int> Values { get; private set; } = values;
    private readonly List<bool> _sumPossible = sumPossible;
    private readonly List<int> _minimumSum = minimumSum;
    private readonly List<int> _maximumSum = maximumSum;

    public static SpecialSumSet? MakeSet(int targetSize, int maximumSum) => MakeSet(new SpecialSumSet([], [true], [0], [0]), targetSize, maximumSum, 1);

    private static SpecialSumSet? MakeSet(SpecialSumSet set, int sizeRemain, int sumRemain, int startVal)
    {
        if (sizeRemain == 0)
            return set;

        if (sizeRemain >= 2 && startVal * sizeRemain >= sumRemain)
            return null;

        var endVal = sumRemain;
        if (set.Values.Count >= 2)
            endVal = Math.Min(set.Values[0] + set.Values[1] - 1, endVal);

        for (var val = startVal; val <= endVal; val++)
        {
            var temp = set.Add(val);
            if (temp == null)
                continue;

            temp = MakeSet(temp, sizeRemain - 1, sumRemain - val, val + 1);
            if (temp != null)
                return temp;
        }
        return null;
    }

    public SpecialSumSet? Add(int val)
    {
        var size = Values.Count;
        var posb = _sumPossible;
        if (Enumerable.Range(0, posb.Count).Any(i => posb.Count > i + val && posb[i + val] && posb[i]))
            return null;

        var newSize = size + 1;
        var minSum = _minimumSum;
        var maxSum = _maximumSum;
        List<int> newMin = [0];
        newMin.AddRange(Enumerable.Range(1, newSize - 1).Select(i => Math.Min(minSum[i], minSum[i - 1] + val)));
        newMin.Add(minSum[size] + val);
        List<int> newMax = [0];
        newMax.AddRange(Enumerable.Range(1, newSize - 1).Select(i => Math.Max(maxSum[i], maxSum[i - 1] + val)));
        newMax.Add(maxSum[size] + val);

        if (Enumerable.Range(0, newSize).Any(i => newMax[i] >= newMin[i + 1]))
            return null;

        var newPosb = new List<bool>(posb);
        newPosb.AddRange(new bool[val]);
        for (int i = newPosb.Count - 1; i >= val; i--)
            newPosb[i] |= newPosb[i - val];

        var newValues = new List<int>(Values) { val };
        return new SpecialSumSet(newValues, newPosb, newMin, newMax);
    }
}