
int limit = 30000;
var memo = new Dictionary<int, List<(int, int, int, int)>>();

for (int x = 1; Layer(x, x, x, 1) <= limit; x++)
    for (int y = x; Layer(x, y, y, 1) <= limit; y++)
        for (int z = y; Layer(x, y, z, 1) <= limit; z++)
        {
            for (int n = 1; ; n++)
            {
                int l = Layer(x, y, z, n);
                if (l > limit)
                    break;
                if (!memo.ContainsKey(l))
                    memo[l] = [];
                memo[l].Add((x, y, z, n));
            }
        }

var result = memo.Where(m => m.Value.Count == 1000).Select(m => m.Key).Min();
Console.WriteLine(result);

static int Layer(int x, int y, int z, int n) =>
    2 * (x * y + y * z + x * z) + 4 * (x + y + z + n - 2) * (n - 1);
