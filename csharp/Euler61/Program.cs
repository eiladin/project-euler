
using Euler;

var numbers = new Dictionary<(int, int), HashSet<int>>();
for (var i = 0; i < 9; i++)
    for (var j = 0; j < 100; j++)
        numbers[(i, j)] = [];

for (var sides = 3; sides <= 8; sides++)
{
    for (var n = 1; ; n++)
    {
        var num = Numerics.GetSidedNumber(sides, n);
        if (num >= 10000)
            break;
        if (num >= 1000)
            numbers[(sides, (int)num / 100)].Add((int)num);
    }
}

Console.WriteLine(Calculate());

int Calculate()
{
    for (var i = 10; i < 100; i++)
    {
        foreach (var num in numbers[(3, i)])
        {
            var result = FindSolutionSum(num, num, 1 << 3, num);
            if (result.HasValue)
                return result.Value;
        }
    }
    return -1;
}

int? FindSolutionSum(int begin, int current, int sidesUsed, int sum)
{
    if (sidesUsed == 504)
    {
        if (current % 100 == begin / 100)
            return sum;
    }
    else
    {
        for (var sides = 4; sides <= 8; sides++)
        {
            if (((sidesUsed >>> sides) & 1) != 0)
                continue;
            foreach (var num in numbers[(sides, current % 100)])
            {
                var result = FindSolutionSum(begin, num, sidesUsed | (1 << sides), sum + num);
                if (result.HasValue)
                    return result.Value;
            }
        }
    }
    return null;
}