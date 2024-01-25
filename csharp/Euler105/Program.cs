List<List<int>> sets = File.ReadAllLines("input.txt")
    .Select(line => line.Split(',').Select(int.Parse).ToList())
    .ToList();

var total = sets.Where(s => new Processor(s).IsSpecial).Sum(s => s.Sum());
Console.WriteLine(total);

internal class Processor
{
    private readonly List<int> _set;
    private readonly HashSet<int> _sumsSeen = [];
    private readonly int[] _minSum;
    private readonly int[] _maxSum;
    private readonly bool _isSpecialSumSet;
    public bool IsSpecial => _isSpecialSumSet;
    public Processor(List<int> set)
    {
        _set = set;
        _minSum = new int[set.Count + 1];
        _maxSum = new int[set.Count + 1];
        ExploreSubsets(0, 0, 0);
        _isSpecialSumSet = _sumsSeen.Count == Math.Pow(2, _set.Count) && Enumerable.Range(0, _set.Count).All(i => _maxSum[i] < _minSum[i + 1]);
    }

    private void ExploreSubsets(int i, int count, int sum)
    {
        if (i == _set.Count)
        {
            _sumsSeen.Add(sum);
            if (_minSum[count] == 0 || sum < _minSum[count])
                _minSum[count] = sum;
            if (_maxSum[count] == 0 || sum > _maxSum[count])
                _maxSum[count] = sum;
        }
        else
        {
            ExploreSubsets(i + 1, count, sum);
            ExploreSubsets(i + 1, count + 1, sum + _set[i]);
        }
    }
}
