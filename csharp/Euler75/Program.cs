using Euler;

var limit = 1_500_001;
var result = new HashSet<int>();
var exclusions = new HashSet<int>();

for (int m = 2; m < Math.Sqrt(limit / 2); m++)
{
    for (int n = m - 1; n > 0; n -= 2)
    {
        if (Numerics.Gcd(m, n) == 1)
        {
            int s = 2 * (m * m + m * n);
            for (int k = 1; k <= limit / s; k++)
            {
                var num = k * s;
                if (!result.Add(num))
                    exclusions.Add(num);
            }
        }
    }
}

result.ExceptWith(exclusions);
Console.WriteLine(result.Count);