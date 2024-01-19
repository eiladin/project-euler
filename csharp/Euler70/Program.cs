using Euler;

var minRatio = double.MaxValue;
var result = 0;

for (var i = 2; i <= 10_000_000; i++)
{
    var totient = Numerics.EulerTotient(i);
    var ratio = (double)i / totient;

    if (IsPermutation(i, totient) && ratio < minRatio)
    {
        minRatio = ratio;
        result = i;
    }
}

Console.WriteLine(result);

static bool IsPermutation(int a, int b) => a.ToString().OrderBy(c => c).SequenceEqual(b.ToString().OrderBy(c => c));