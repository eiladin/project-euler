using Euler;

var limit = 1_000_000_000_000;
HashSet<long> results = [];

for (var a = 2L; a < Math.Pow(10, 4); a++)
{
    for (var b = 1L; b < Math.Min(a, limit / (a * a * a)); b++)
    {
        if (Numerics.Gcd(a, b) > 1)
            continue;
        for (var c = 1L; c <= Math.Sqrt(limit / (a * a * a) / b); c++)
        {
            var n = a * a * a * b * c * c + c * b * b;
            if (Numerics.IsSquare(n))
                results.Add(n);
        }
    }
}

Console.WriteLine(results.Sum());
