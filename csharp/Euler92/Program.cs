using System.Diagnostics;
using Euler;

Stopwatch sw = new();
sw.Start();

var nums = new Dictionary<int, bool>()
{
    { 1, false },
    { 89, true }
};

for (var i = 2; i < 10_000_000; i++)
{
    var num = i;
    while (num != 1 && num != 89)
    {
        num = Numerics.GetDigits(num).Sum(x => x * x);
        if (nums.TryGetValue(num, out bool value))
            num = value ? 89 : 1;
    }
    nums.TryAdd(i, num == 89);
}

Console.WriteLine(nums.Count(x => x.Value));
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds + "ms");