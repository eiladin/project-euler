using Euler;

List<int> digits = [1, 2, 3, 4, 5, 6, 7, 8, 9];
List<long> options = [];

var permutations = Collections.GetPermutations(digits);
foreach (var permutation in permutations)
{
    var ngon = new Ngon([.. permutation]);
    if (ngon.IsMagic)
        options.Add(ngon.SolutionSet);
}

Console.WriteLine(options.Max());


internal class Ngon(int[] numbers)
{
    private readonly int[] _numbers = [.. numbers, 10];

    private int Line1Sum { get { return _numbers[7] + _numbers[0] + _numbers[1]; } }
    private int Line2Sum { get { return _numbers[8] + _numbers[1] + _numbers[2]; } }
    private int Line3Sum { get { return _numbers[9] + _numbers[2] + _numbers[3]; } }
    private int Line4Sum { get { return _numbers[5] + _numbers[3] + _numbers[4]; } }
    private int Line5Sum { get { return _numbers[6] + _numbers[4] + _numbers[0]; } }
    private int Line1 => 100 * _numbers[7] + 10 * _numbers[0] + _numbers[1];
    private int Line2 => 100 * _numbers[8] + 10 * _numbers[1] + _numbers[2];
    private int Line3 => 100 * _numbers[9] + 10 * _numbers[2] + _numbers[3];
    private int Line4 => 100 * _numbers[5] + 10 * _numbers[3] + _numbers[4];
    private int Line5 => 100 * _numbers[6] + 10 * _numbers[4] + _numbers[0];
    public bool IsMagic => Line1Sum == Line2Sum && Line1Sum == Line3Sum && Line1Sum == Line4Sum && Line1Sum == Line5Sum;
    public long SolutionSet
    {
        get
        {
            var solutionSet = new int[5];
            List<int> temp = [Line1, Line2, Line3, Line4, Line5];
            int min = 1000, index = 0;
            for (var i = 0; i < temp.Count; i++)
                if (temp[i] < min)
                {
                    min = temp[i];
                    index = i;
                }
            for (var i = 0; i < index; i++)
                temp.Add(temp[i]);
            temp.CopyTo(index, solutionSet, 0, 5);
            var solution = solutionSet.Aggregate("", (acc, x) => acc + x);
            return long.Parse(solution);
        }
    }
}
