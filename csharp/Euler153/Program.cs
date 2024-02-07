using Euler;

var n = 100_000_000;
Dictionary<int, long> dict = [];

for (var i = 1; i * i <= n; i++)
    for (var j = 1; j <= Math.Min(i, Math.Sqrt(n - i * i)); j++)
        if (Numerics.Gcd(i, j) == 1)
        {
            var key = i * i + j * j;
            var increment = i == j ? i * 2 : (i + j) * 2;
            if (!dict.ContainsKey(key))
                dict[key] = 0;
            dict[key] += increment;
        }

var ans = Sss(n);

ans += dict.Select(kvp => kvp.Key > n / 2 ? kvp.Value : kvp.Value * Sss(n / kvp.Key)).Sum();

Console.WriteLine(ans);

static long Sss(long n)
{
    var result = n * n;
    for (var i = 1; i <= n / 2; i++)
        result -= n % i;
    var k = (n - 1) / 2;
    result -= k * (1 + k) / 2;
    return result;
}
