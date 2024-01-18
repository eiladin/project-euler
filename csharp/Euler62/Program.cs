using System.Numerics;
using System.Runtime.CompilerServices;

var digits = string.Empty;
BigInteger minCube = -1;
var n = 100;
var d = 5;
var cubes = new Dictionary<string, List<BigInteger>>();

while (minCube == -1 || digits.Length < minCube.ToString().Length)
{
    var c = BigInteger.Pow(n, 3);
    digits = c.ToString().OrderBy(x => x).Aggregate(string.Empty, (acc, x) => acc + x);
    if (cubes.TryGetValue(digits, out List<BigInteger>? value))
    {
        value.Add(c);
        if (value.Count == d)
            minCube = value.Min();
    }
    else
        cubes.Add(digits, [c]);
    n++;
}

Console.WriteLine(minCube);