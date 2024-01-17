DateTime start = DateTime.Now;
List<string> wildcards = [];
var primes = Primes(1_000_000);
HashSet<string> searched = [];

for (int x = 0; x < primes.Length; x++)
{
    if (!primes[x])
        continue;
    wildcards.Clear();
    GenWildcardStrings(x.ToString(), 0, searched, wildcards);
    for (int y = 1; y < wildcards.Count; y++)
    {
        int count = 0;
        var list = new List<int>();
        for (int z = 0; z < 10; z++)
        {
            int num = int.Parse(wildcards[y].Replace('*', z.ToString()[0]));
            if (num.ToString().Length < wildcards[y].Length)
                continue;
            if (primes[num])
            {
                list.Add(num);
                count += 1;
            }
        }
        if (count >= 8)
        {
            Console.WriteLine(list.Min());
            return;
        }
    }
}

static void GenWildcardStrings(string s, int index, HashSet<string> searched, List<string> wildcards)
{
    if (index > 0 && !searched.Contains(s))
    {
        wildcards.Add(s);
        searched.Add(s);
    }
    for (int x = index; x < s.Length; x++)
        GenWildcardStrings(CreatePlaceholder(s, x), x + 1, searched, wildcards);
}

static string CreatePlaceholder(string s, int index) => s[..index] + '*' + s[(index + 1)..];

static bool[] Primes(int n)
{
    bool[] a = new bool[n + 1];
    for (int i = 0; i < n; i++)
        a[i] = true;
    int limit = (int)Math.Sqrt(n);
    a[0] = false;
    a[1] = false;
    for (int i = 4; i <= n; i += 2)
        a[i] = false;
    for (int i = 3; i <= limit; i += 2)
    {
        if (a[i])
        {
            int step = i * 2;
            for (int j = i * i; j <= n; j += step)
                a[j] = false;
        }
    }
    return a;
}