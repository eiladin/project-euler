
List<string> words = File.ReadAllText("input.txt").Split(',').Select(w => w.Trim('"')).ToList();

Console.WriteLine(words.Count(w => IsTriangleWord(w)));

static bool IsTriangleWord(string s)
{
    int sum = 0;
    foreach (char c in s)
        sum += c - 'A' + 1;
    int n = 1;
    while (true)
    {
        int t = n * (n + 1) / 2;
        if (t == sum)
            return true;
        else if (t > sum)
            return false;
        n++;
    }
}