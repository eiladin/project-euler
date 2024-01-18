using Euler;

DateTime start = DateTime.Now;
List<string> wildcards = [];
var primes = Primes.Sieve(1_000_000);
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