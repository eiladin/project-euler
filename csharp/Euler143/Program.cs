using Euler;

var limit = 120000;
var pairs = GeneratePairs();
var res = new HashSet<int>();
foreach (var pair in pairs)
    foreach (var q in pair.Value)
        if (pairs.TryGetValue(q, out HashSet<int>? value))
            foreach (var r in pair.Value.Intersect(value))
                res.Add(pair.Key + q + r);

Console.WriteLine(res.Where(x => x <= limit).Sum());

static Dictionary<int, HashSet<int>> GeneratePairs(int limit = 120000)
{
    var pairs = new Dictionary<int, HashSet<int>>();
    for (var i = 2; i < 346; i++)
        for (var j = 1; j < i; j++)
            if (Numerics.Gcd(i, j) == 1 && (i - j) % 3 != 0)
            {
                var q = 2 * i * j + j * j;
                var r = i * i - j * j;
                if (q < r)
                    (r, q) = (q, r);
                for (int k = 1; k <= limit / q; k++)
                {
                    if (!pairs.ContainsKey(k * q))
                        pairs[k * q] = [];
                    pairs[k * q].Add(k * r);
                }
            }

    return pairs;
}

