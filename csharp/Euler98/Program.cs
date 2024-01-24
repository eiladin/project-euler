var words = File.ReadAllText("input.txt").Split(',').Select(w => w.Trim('"')).ToList();
var anagrams = words.GroupBy(w => new string(w.OrderBy(c => c).ToArray())).ToDictionary(g => g.Key, g => g.ToList());

var max = anagrams.Keys.SelectMany(key => anagrams[key]
    .SelectMany((anagram, i) => anagrams[key]
        .Skip(i + 1)
        .Select(anagram2 => new { Anagram1 = anagram, Anagram2 = anagram2 }))
    .Select(pair => FindMax(pair.Anagram1, pair.Anagram2, 0, Enumerable.Repeat(-1, 26).ToArray(), new bool[10])))
    .Max();

Console.WriteLine(max);

static int FindMax(string a, string b, int index, int[] assignments, bool[] isUsed)
{
    if (index == a.Length)
    {
        if (assignments[a[0] - 'A'] == 0 || assignments[b[0] - 'A'] == 0)
            return 0;

        var aNum = int.Parse(new string(a.Select(c => (char)('0' + assignments[c - 'A'])).ToArray()));
        var bNum = int.Parse(new string(b.Select(c => (char)('0' + assignments[c - 'A'])).ToArray()));
        if (Math.Sqrt(aNum) % 1 == 0 && Math.Sqrt(bNum) % 1 == 0)
            return Math.Max(aNum, bNum);
        return 0;
    }

    var max = 0;
    for (var i = 0; i < 10; i++)
    {
        if (isUsed[i])
            continue;
        isUsed[i] = true;
        assignments[a[index] - 'A'] = i;
        max = Math.Max(max, FindMax(a, b, index + 1, assignments, isUsed));
        isUsed[i] = false;
    }

    return max;
}

